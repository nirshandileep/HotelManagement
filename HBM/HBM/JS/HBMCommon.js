
//Top Message
function ShowTopMessage(content) {
    var wrapper = $('<div />').addClass('msg_wrapper');
    var save_content = $('<div />').addClass('msg_content').html(content);
        wrapper.append(save_content);

        wrapper.appendTo('#dvTopMessage');
        setTimeout(function () {
            wrapper.fadeOut(function () {
                wrapper.remove();
            });
        }, 1000);
}