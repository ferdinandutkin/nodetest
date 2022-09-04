var ElementUtils = ElementUtils || {
    getName(element) {
        console.log(element);
        return element.toString();
    },
    getBoundingClientRect(element) {
        return element.getBoundingClientRect();
    }
};