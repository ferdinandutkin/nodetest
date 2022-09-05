var ElementUtils = ElementUtils || {
    getName(element) {
        console.log(element);
        return element.toString();
    },
    getBoundingClientRect(element) {
        return element.getBoundingClientRect();
    },
    getOffset(element) {
        const x = $(element).offset().left;
        const y = $(element).offset().top;
        return {x: Math.trunc(x), y: Math.trunc(y)}
    },
    
    getWidth(element) {
        return Math.trunc($(element).width());
    },
    getHeight(element) {
        return Math.trunc($(element).height());
    }


};