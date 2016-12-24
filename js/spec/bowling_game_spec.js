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

  it('all 5-es scores 150', function () {
    for(var i=0; i<21; i++) {
      game.roll(5);
    }
    expect(game.score()).toEqual(150);
  });

  it('strike-2-3 scores 20', function () {
    game.roll(10);
    game.roll(2);
    game.roll(3);
    expect(game.score()).toEqual(10+2+3 + 2+3)
  });

  it('strike-strike-2-3 scores 20', function () {
    game.roll(10);
    game.roll(10);
    game.roll(2);
    game.roll(3);
    expect(game.score()).toEqual(10+10+2 + 10+2+3 + 2+3)
  });

  it('a perfect game scores 300', function () {
    for(var i=0; i<12; i++) {
      game.roll(10);
    }
    expect(game.score()).toEqual(300)
  });
});
