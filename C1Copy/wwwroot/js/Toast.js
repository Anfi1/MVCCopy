var option =
    {
        animation: true,
        delay: 3000
    }
function Toasty()
{
    var ToastHTMLElement = document.getElementById("SaveToast");

    var toastElement = new bootstrap.Toast(ToastHTMLElement, option);

    toastElement.show();

}