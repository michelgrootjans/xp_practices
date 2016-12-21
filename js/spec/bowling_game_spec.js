describe('A new game of bowling', function () {
  it('scores 0', function () {
    expect(new BowlingGame().score()).toEqual(0);
  });
});

describe('Rolling', function () {
  var game;
  beforeEach(function () {
    game = new BowlingGame();
  });

  it('O scores 0', function () {
    game.roll(0);
    expect(game.score()).toEqual(0);
  });

  it('1 scores 1', function () {
    game.roll(1);
    expect(game.score()).toEqual(1);
  });

  it('1 twice scores 2', function () {
    game.roll(1);
    game.roll(1);
    expect(game.score()).toEqual(2);
  });

  it('spare-2 scores 14', function () {
    game.roll(6);
    game.roll(4);
    game.roll(2);
    expect(game.score()).toEqual(6 + 4 + 2 + 2);
  });
});
