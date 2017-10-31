
function myFunction(courseId, titre, description, nbPage, dateAjout) {
    alert('courseId' + courseId);
    $('#modal').append(
       + '<div id="myModal" class="modal fade" role="dialog">'
  +'<div class="modal-dialog">'

   + '<!-- Modal content-->'
    +'<div class="modal-content">'
     + '<div class="modal-header">'
      +  '<button type="button" class="close" data-dismiss="modal">&times;</button>'
       + ' <h4 class="modal-title">Modal ' + titre + '</h4>'
      +'</div>'
      + '<div class="modal-body">'
     
      + '<p>' + "Description : " + description + '</p>'
       + '<p>' + "Nombre de page : " + nbPage + '</p>'
        + '<p>' + "Date d'ajout :" + dateAjout + '</p>'
      
     
       
      +'</div>'
      +'<div class="modal-footer">'
      + ' <button type="button" class="btn btn-default" onclick="close()"   data-dismiss="modal">Close</button>'
      +'</div>'
    +'</div>'

  +'</div>'
+'</div>'

        );
    
    
           
       
    

}


function close(){

    $('#modal').remove();
}