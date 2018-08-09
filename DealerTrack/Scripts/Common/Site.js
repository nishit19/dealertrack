var dealerTrack = dealerTrack || {};
dealerTrack.common = (function (common) {
    //animate a section with pop effect
    common.animateSection = function(elementAccessor) {
        var speed = 2000;
        var elementOffset = $('.body-content').offset();
        var offset = elementOffset.left * 0.8 + elementOffset.top;
        var delay = (parseFloat(offset / speed) - 0.3).toFixed(2);
        $(elementAccessor)
            .css('-webkit-animation-delay', delay + 's')
            .css('-o-animation-delay', delay + 's')
            .css('animation-delay', delay + 's')
            .addClass('animated');
    }
    return common;
})(dealerTrack.common || {});
