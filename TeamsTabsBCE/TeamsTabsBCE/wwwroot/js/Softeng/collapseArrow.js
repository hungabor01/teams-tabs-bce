$('.collapse').on('show.bs.collapse', function (e) {
    var id = e.target.id;
    var selector = 'a[href="#' + id + '"]';
    var i = $(selector).find('i');
    if (!i || i.length == 0) {
        return;
    }

    i[0].classList.remove('fa-circle-arrow-down');
    i[0].classList.add('fa-circle-arrow-up');
});

$('.collapse').on('hide.bs.collapse', function (e) {
    var id = e.target.id;
    var selector = 'a[href="#' + id + '"]';
    var i = $(selector).find('i');
    if (!i || i.length == 0) {
        return;
    }

    i[0].classList.remove('fa-circle-arrow-up');
    i[0].classList.add('fa-circle-arrow-down');
});