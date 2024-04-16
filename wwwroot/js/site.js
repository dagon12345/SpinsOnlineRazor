// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {

   
    // inspired by http://jsfiddle.net/arunpjohny/564Lxosz/1/
   //  $('.table-responsive-stack').find("th").each(function (i) {
       
   //     $('.table-responsive-stack td:nth-child(' + (i + 1) + ')').prepend('<span class="table-responsive-stack-thead">'+ $(this).text() + ':</span> ');
   //     $('.table-responsive-stack-thead').hide();
   //  });
 
    
    
    
    
 $( '.table-responsive-stack' ).each(function() {
   var thCount = $(this).find("th").length; 
    var rowGrow = 100 / thCount + '%';
    //console.log(rowGrow);
    $(this).find("th, td").css('flex-basis', rowGrow);   
 });
    
    
    
    
 function flexTable(){
    if ($(window).width() < 768) {
       
    $(".table-responsive-stack").each(function (i) {
       $(this).find(".table-responsive-stack-thead").show();
       $(this).find('thead').hide();
    });
       
     
    // window is less than 768px   
    } else {
       
       
    $(".table-responsive-stack").each(function (i) {
       $(this).find(".table-responsive-stack-thead").hide();
       $(this).find('thead').show();
    });
       
       
 
    }
 // flextable   
 }      
  
 flexTable();
    
 window.onresize = function(event) {
     flexTable();
 };
    
    
   
 // document ready  
 });
 
 
 function ExportToExcel(type, fn, dl) {
   var elt = document.getElementById('tbl_exporttable_to_xls');
   var wb = XLSX.utils.table_to_book(elt, { sheet: "sheet1" });
   return dl ?
     XLSX.write(wb, { bookType: type, bookSST: true, type: 'base64' }):
     XLSX.writeFile(wb, fn || ('MySheetName.' + (type || 'xlsx')));
}

 
 