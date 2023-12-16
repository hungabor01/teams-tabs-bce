// "step", "week1-list2-step6" => 6
// "week", "week2-list1-step3" => 2
function extractTaskNumber(category, taskValue) {
    var pattern = new RegExp(`${category}(\\d+)`);
    var match = taskValue.match(pattern);
    if (match) {
        return match[1];
    }

    return null;
}
