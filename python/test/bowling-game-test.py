import unittest
from app.game import Game

class BowlingGameTest(unittest.TestCase):
  def setUp(self):
    self.game = Game()

  def test_new_game(self):
    self.assertEqual(self.game.score(), 0)
