var rows = document.getElementById('ClientBody').getElementsByTagName('tr');
for (var i = 0; i < rows.length; i++) {
    (rows)[i].getElementsByTagName('td')[0].addEventListener("dblclick", function () {
        addInput(this);
    });
}

function closeInput(elm) {
    var td = elm.parentNode;
    var text = elm.value;
    td.removeChild(elm);
    td.innerHTML = text;
    $.ajax({
        url: '/Database/EditClientName/',
        type: 'post',
        data: {Name: text, ClientID: td.id},
        success: function (td) {
            Toasty();
        }
    });
}

function addInput(elm) {
    var innerHTML = elm.innerHTML;
    elm.innerHTML = '';

    var input = document.createElement('input');
    input.setAttribute('type', 'text');
    input.setAttribute('value', innerHTML);
    input.setAttribute('onBlur', 'closeInput(this)');
    elm.appendChild(input);
    input.focus();
    input.addEventListener("keyup", function (e) {
        if (e.code === "Enter") {
            closeInput(this);
        }
    })
}
