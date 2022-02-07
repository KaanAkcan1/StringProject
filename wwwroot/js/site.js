$(function () {
    getWords();
    $('.btn').on('click', function (e) {
        e.preventDefault();
        saveWords();

    });
    getLOG();
});

var showWords = function (words) {
    var s = "";

    for (var i = 0; i < words.length; i++) {
        s += words[i] + "\n";
    }

    $('#word-area').val(s);
};

var getWords = function () {
    $.getJSON("/show-string")
        .done(function (response) {
            showWords(response);
        });
}

var saveWords = function () {
    var s = $('#word-area').val();
    var words = s.split('\n');
    // $.postJSON('/save-string', words)
    //     .done(function (response) {
    //         if (response && response.success) {
    //             alert('Kelimeler kaydedildi .');
    //         } else {
    //             alert('Bir hata oluştu.');
    //         }
    //     });
    $.ajax({
        data: JSON.stringify(words),
        dataType:"json",
        url: '/save-string',
        type: 'post',
        contentType: 'application/json',
        cache: false,
        success: function (response) {
            if (response && response.value.success) {
                alert('Kelimeler kaydedildi .');
            } else {
                alert('Bir hata oluştu.');
            }
        },
        error: function (err) {
            console.log(err);
        }
    })
}



var getLOG = function () {
    $.getJSON('/show-logs')
        .done(function (response) {
            console.log(response);
            $('#word-log tbody').html('');
            for (var i = 0; i < response.length; i++) {
                $('#word-log tbody').append('<tr><td>' + response[i].givingDate + '</td><td>' + response[i].ipAdress + '</td><td>' + response[i].url + '</td><td>' + response[i].word + '</td></tr>')
            }
        });
};

