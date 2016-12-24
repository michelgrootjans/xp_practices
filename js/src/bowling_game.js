var BowlingGame = function () {
  var rolls = [];

  function roll(pins) {
    rolls.push(pins);
    if(pins == 10) rolls.push(0);
  }

  function score() {
    var score = 0;
    for (var frame = 1; frame <= 10; frame++) {
      score += scoreFor(frame);
    }
    return score;
  }

  function scoreFor(frame) {
    if(isStrike(frame))
      return standardScoreOf(frame) + strikeBonusFor(frame);
    if(isSpare(frame))
      return standardScoreOf(frame) + spareBonusFor(frame);
    return standardScoreOf(frame);
  }

  function isStrike(frame) {
    return firstRollOf(frame) == 10;
  }

  function strikeBonusFor(frame) {
    return firstRollOf(frame + 1) + secondRollOf(frame + 1);
  }

  function isSpare(frame) {
    return standardScoreOf(frame) == 10;
  }

  function spareBonusFor(frame) {
    return firstRollOf(frame + 1);
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
