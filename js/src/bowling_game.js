var BowlingGame = function () {
  var rolls = [];

  function roll(pins) {
    rolls.push(pins);
  }

  function score() {
    var score = 0;
    for (var frame = 1; frame <= 10; frame++) {
      score += scoreFor(frame);
    }
    return score;
  }

  function scoreFor(frame) {
    return standardScoreOf(frame);
  }

  function standardScoreOf(frame) {
    return firstRollOf(frame) + secondRollOf(frame);
  }

  function firstRollOf(frame) {
    return rollAt((frame - 1) * 2);
  }

  function secondRollOf(frame) {
    return rollAt((frame - 1) * 2 + 1);
  }

  function rollAt(index) {
    return rolls[index] || 0;
  }

  return {roll: roll, score: score};
};
