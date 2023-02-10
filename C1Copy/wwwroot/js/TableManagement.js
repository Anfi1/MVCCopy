var elements= document.getElementById('ClientBody').getElementsByTagName('tr');
for(var i=0; i<elements.length;i++)
{
    var row = (elements)[i];
    row.cells[1].addEventListener("dblclick", function(){
        window.location = this.getElementsByTagName('a')[1].getAttribute('href');
    });
}