function extractTaskNumber(category, taskValue) {
    var pattern = new RegExp(`${category}(\\d+)`);
    var match = taskValue.match(pattern);
    if (match) {
        return match[1];
    }

    return null;
}
