import sys
from PyQt5.QtWidgets import *
from PyQt5.QtCore import *
from PyQt5.QtGui import *
from PyQt5.QtWidgets import QStyleFactory
from random import randint
from itertools import combinations


class Window(QWidget):
    def __init__(self):
        QWidget.__init__(self)
        self._pressed_buttons = [False for i in range(9)]
        self._buttons = []
        self.turn_player = True
        self.win_combinations = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [0, 3, 6], [1, 4, 7], [2, 5, 8], [0, 4, 8], [2, 4, 6]]
        self.turns_player = []
        self.turns_enemy = []
        self.enemy_style = "background-color: red; font: 60px;"
        self.player_style = "background-color: green; font: 60px;"
        self.init_GUI()

    def init_GUI(self):
        self.setWindowTitle("TicTacToe")
        layout = QGridLayout()
        self.setLayout(layout)
        self.setFixedSize(325, 325)
        layout.setSpacing(0)
        for i in range(9):
            self._buttons.append(QPushButton())
            self._buttons[i].setFixedSize(100, 100)
            self._buttons[i].setStyleSheet("font: 60px;")
            self._buttons[i].clicked.connect(lambda ch, name = i: self.on_button_clicked(name))
            layout.addWidget(self._buttons[i], i // 3, i % 3)
        self.label = QLabel()
        layout.addWidget(self.label, 0, 0)
        self.label.setVisible(False)
        self.label.setAlignment(Qt.AlignCenter)

    def on_button_clicked(self, index: int):
        if not self._pressed_buttons[index]:
            self.set_button(index, False, self.player_style)
            if self.is_win_combination(self.turns_player):
                self.exit_game("WIN!")
                return
            self.enemy_turn()
            if self.is_win_combination(self.turns_enemy):
                self.exit_game("LOSE!")
                return
            if False not in self._pressed_buttons:
                self.exit_game("DRAW!")

    def is_win_combination(self, arr: list):
        for j in combinations(arr, 3):
            for x in self.win_combinations:
                temp = 0
                for i in range(3):
                    if j[i] in x:
                        temp += 1
                    if temp == 3:
                        return True
        return False

    def get_need_combination(self):
        # 0,1,2 ; 3,4,5 ; 6,7,8; 0,3,6 ; 1,4,7 ; 2,5,8 ; 0,4,8 ; 2,4,6
        for i in self.win_combinations:
            x = self.check_comb(i, self.turns_enemy, self.turns_player)
            if x != -1:
                arr = [x, i]
                return arr
        for i in self.win_combinations:
            x = self.check_comb(i, self.turns_player, self.turns_enemy)
            if x != -1:
                arr = [x, i]
                return arr
        return [-1, -1]

    def check_comb(self, comb1, you, enemy):
        temp = 0
        for i in range(len(you)):
            if list(you)[i] in comb1:
                temp += 1
            if temp == 2:
                for j in range(len(comb1)):
                    if comb1[j] not in list(you) and comb1[j] not in list(enemy):
                        return comb1[j]
        return -1

    def enemy_turn(self):
        if False in self._pressed_buttons:
            x = self.get_need_combination()
            if x[0] != -1:
                self.set_button(x[0], True, self.enemy_style)
            else:
                rand_pos = randint(0, 8)
                while self._pressed_buttons[rand_pos]:
                    rand_pos = randint(0, 8)
                self.set_button(rand_pos, True, self.enemy_style)

    def set_button(self, index: int, is_enemy: bool, style: str):
        symbol = ""
        if is_enemy:
            symbol += "O"
            self.turns_enemy.append(index)
        else:
            symbol += "X"
            self.turns_player.append(index)
        self._buttons[index].setText(symbol)
        self._buttons[index].setStyleSheet(style)
        self._pressed_buttons[index] = True

    def exit_game(self, text: str):
        for i in range(len(self._buttons)):
            self._buttons[i].setText("")
            # self._buttons[i].setEnabled(False)
            self._buttons[i].setVisible(False)
        self.label.setVisible(True)
        self.label.setText(text)
        self.label.setStyleSheet("font: 80px;")


app = QApplication(sys.argv)
app.setStyle(QStyleFactory.create("Fusion"))
screen = Window()
screen.show()
sys.exit(app.exec_())
