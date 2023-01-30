var elements= document.getElementById('ClientBody').getElementsByTagName('tr');
for(var i=0; i<elements.length;i++)
{
    (elements)[i].addEventListener("dblclick", function(){
        window.location = 'Database/Edit/' + this.cells[1].getAttribute('value');
    });
}