<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs"
    Inherits="RegistroTiemposLaborales.Administrador" StylesheetTheme="TemaRoute" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Registro De Tiempos</title>
    <style type="text/css">
        .style1
        {
            width: 140px;
        }
        .style3
        {
            width: 280px;
        }
        .style4
        {
            width: 60px;
        }
        html, body, form
        {
            margin: 0px;
            height: 100%;
        }
    </style>

    <script type="text/javascript" language="javascript">


        function CambioDiaTrabajo(sender, args) {
            var txt = document.getElementById('TxtFechaHora');
            var txtJornada = document.getElementById('TxtDiaTrabajo');
            temp = txt.value.toString().substring(10)

            txt.value = txtJornada.value;

            sundayDate = new Date(txtJornada.value.toString().substring(6, 10), txtJornada.value.toString().substring(3, 5) - 1, txtJornada.value.toString().substring(0, 2));
            var cal = $find("CalendarExtender1");
            cal._selectedDate = sundayDate;




            txt.value = txt.value + temp;



        }

        function CambioFecha() {




            var txt = document.getElementById('TxtFechaHora');

            var cal = $find("CalendarExtender1");

            sender = cal;



            //            sundayDate = new Date(txt.value.toString().substring(6, 10), txt.value.toString().substring(3, 5) - 1, txt.value.toString().substring(0, 2));

            //            cal._selectedDate = sundayDate;



            txt.defaultvalue;
            txt.value = txt.value + txt.defaultValue.substring(10);

        }



        function TecleoFX(evt) {




            if (document.selection) {

            }
            else {

                var ctrl = (typeof evt.target != 'undefined') ? evt.target : evt.srcElement;

                if (document.getElementById(ctrl.id.toString().substring(0, ctrl.id.toString().indexOf('txt')) + "btnGuardar") != null)
                    return;

                ctrl.blur();
                ctrl.focus();

            }



        }

        function Maus(evt) {





            if (document.selection) {

                var ctrl = (typeof evt.target != 'undefined') ? evt.target : evt.srcElement;


                ctrl.blur();

                //                                  
            }



        }



        function TecleoIE(evt) {





            if (document.selection) {

                var ctrl = (typeof evt.target != 'undefined') ? evt.target : evt.srcElement;

                if (document.getElementById(ctrl.id.toString().substring(0, ctrl.id.toString().indexOf('txt')) + "btnGuardar") != null)
                    return;


                ctrl.blur();
                ctrl.focus();

                //                                  
            }



        }


        function Borrar() {

            var ctrl =
 document.getElementById("TxtFechaHora");





            var saveText = ctrl.value;
            ctrl.focus();

            //////////////////////////////////////
            var range;
            var specialchar = String.fromCharCode(1);
            var $before, $after, $selection;
            var pos;
            var temp;
            //////////////////////////////////////
            if (document.selection) {//iexplorer

                range = document.selection.createRange();
                range.text = specialchar;
                pos = ctrl.value.indexOf(specialchar);
                ctrl.value = saveText;
                range = ctrl.createTextRange();
                range.move('character', pos);
                range.select();
            } else if (typeof ctrl.selectionStart != 'undefined') {//others
                pos = ctrl.selectionStart;
                ctrl.value = saveText;
            }

            /////////////////////////////////////


            var brinko = 1;




            ///////////////////

            if (pos == 1) {
                ctrl.value = "0" + ctrl.value.toString().substring(1, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
            }
            else if (pos == 2) {
                ctrl.value = ctrl.value.toString().substring(0, 1) + "1" + ctrl.value.toString().substring(2, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;

            }
            else if (pos == 4) {
                ctrl.value = ctrl.value.toString().substring(0, 3) + "0" + ctrl.value.toString().substring(4, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;

            }
            else if (pos == 5) {
                ctrl.value = ctrl.value.toString().substring(0, 4) + "1" + ctrl.value.toString().substring(5, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
            }
            else if (pos == 7) {
                ctrl.value = ctrl.value.toString().substring(0, 6) + "2" + ctrl.value.toString().substring(7, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
            }
            else if (pos == 8) {
                ctrl.value = ctrl.value.toString().substring(0, 7) + "0" + ctrl.value.toString().substring(8, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
            }
            else if (pos == 9) {
                ctrl.value = ctrl.value.toString().substring(0, 8) + "0" + ctrl.value.toString().substring(9, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
            }
            else if (pos == 10) {
                ctrl.value = ctrl.value.toString().substring(0, 9) + "0" + ctrl.value.toString().substring(10, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;

            }
            else if (pos == 12) {
                ctrl.value = ctrl.value.toString().substring(0, 11) + "0" + ctrl.value.toString().substring(12, 24);

            }
            else if (pos == 13) {
                ctrl.value = ctrl.value.toString().substring(0, 12) + "1" + ctrl.value.toString().substring(13, 24);


            }
            else if (pos == 15) {
                ctrl.value = ctrl.value.toString().substring(0, 14) + "0" + ctrl.value.toString().substring(15, 24);

            }
            else if (pos == 16) {
                ctrl.value = ctrl.value.toString().substring(0, 15) + "0" + ctrl.value.toString().substring(16, 24);


            }
            else if (pos == 18) {
                ctrl.value = ctrl.value.toString().substring(0, 17) + "0" + ctrl.value.toString().substring(18, 24);

            }
            else if (pos == 19) {
                ctrl.value = ctrl.value.toString().substring(0, 18) + "0" + ctrl.value.toString().substring(19, 24);


            }
            else if (pos >= 20) {

                ctrl.value = ctrl.value.toString().substring(0, 20) + "a.m.";
                pos = 19;
                brinko = 0;

            }


            ///////////////////

            if (document.selection) {//iexplorer

                range = ctrl.createTextRange();


                range.move('character', pos - brinko);


                range.select();


                ctrl.defaultValue = ctrl.value;
                window.event.returnValue = false;
            } else if (typeof ctrl.selectionStart != 'undefined') {//others
                ctrl.setSelectionRange(pos - brinko, pos - brinko);
                ctrl.defaultValue = ctrl.value;
            }


        }


        function Numeros(key) {
            var ctrl =
 document.getElementById("TxtFechaHora");
            var saveText = ctrl.value;
            ctrl.focus();

            //////////////////////////////////////
            var range;
            var specialchar = String.fromCharCode(1);
            var $before, $after, $selection;
            var pos;
            var temp;
            //////////////////////////////////////
            if (document.selection) {//iexplorer

                range = document.selection.createRange();
                range.text = specialchar;
                pos = ctrl.value.indexOf(specialchar);
                ctrl.value = saveText;
                range = ctrl.createTextRange();
                range.move('character', pos);
                range.select();
            } else if (typeof ctrl.selectionStart != 'undefined') {//others

                pos = ctrl.selectionStart;
                ctrl.value = saveText;
            }

            var brinko = 1;
            var tecla = String.fromCharCode(key)
            if (key == 96) tecla = "0"; // numpad 0
            if (key == 97) tecla = "1"; // numpad 1
            if (key == 98) tecla = "2"; // numpad 2
            if (key == 99) tecla = "3"; // numpad 3
            if (key == 100) tecla = "4"; // numpad 4
            if (key == 101) tecla = "5"; // numpad 5
            if (key == 102) tecla = "6"; // numpad 6
            if (key == 103) tecla = "7"; // numpad 7
            if (key == 104) tecla = "8"; // numpad 8
            if (key == 105) tecla = "9"; // numpad 9



            ///////////////////

            if (pos == 0 && (key >= 96 && key <= 99 || key >= 48 && key <= 51)) {
                ctrl.value = tecla + ctrl.value.toString().substring(1, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
            }
            else if (pos == 1 && (key >= 97 && key <= 105 || key >= 49 && key <= 57)) {
                ctrl.value = ctrl.value.toString().substring(0, 1) + tecla + ctrl.value.toString().substring(2, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
                brinko = 2;
            }
            else if (pos == 3 && (key >= 96 && key <= 97 || key >= 48 && key <= 49)) {
                ctrl.value = ctrl.value.toString().substring(0, 3) + tecla + ctrl.value.toString().substring(4, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
            }
            else if (pos == 4 && (key >= 96 && key <= 105 || key >= 48 && key <= 57)) {
                ctrl.value = ctrl.value.toString().substring(0, 4) + tecla + ctrl.value.toString().substring(5, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
                brinko = 2;
            }
            else if (pos == 6 && (key >= 97 && key <= 105 || key >= 49 && key <= 57)) {
                ctrl.value = ctrl.value.toString().substring(0, 6) + tecla + ctrl.value.toString().substring(7, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
            }
            else if (pos == 7 && (key >= 96 && key <= 105 || key >= 48 && key <= 57)) {
                ctrl.value = ctrl.value.toString().substring(0, 7) + tecla + ctrl.value.toString().substring(8, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
            }
            else if (pos == 8 && (key >= 96 && key <= 105 || key >= 48 && key <= 57)) {
                ctrl.value = ctrl.value.toString().substring(0, 8) + tecla + ctrl.value.toString().substring(9, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
            }
            else if (pos == 9 && (key >= 96 && key <= 105 || key >= 48 && key <= 57)) {
                ctrl.value = ctrl.value.toString().substring(0, 9) + tecla + ctrl.value.toString().substring(10, 24);
                temp = ctrl.value;
                var cal = $find("CalendarExtender1");
                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));
                cal._selectedDate = sundayDate;
                cal.set_selectedDate(sundayDate);
                ctrl.value = temp;
                brinko = 2;
            }
            else if (pos == 11 && (key >= 96 && key <= 97 || key >= 48 && key <= 49)) {
                ctrl.value = ctrl.value.toString().substring(0, 11) + tecla + ctrl.value.toString().substring(12, 24);

            }
            else if (pos == 12 && (key >= 96 && key <= 105 || key >= 48 && key <= 57)) {
                ctrl.value = ctrl.value.toString().substring(0, 12) + tecla + ctrl.value.toString().substring(13, 24);

                brinko = 2;
            }
            else if (pos == 14 && (key >= 96 && key <= 101 || key >= 48 && key <= 53)) {
                ctrl.value = ctrl.value.toString().substring(0, 14) + tecla + ctrl.value.toString().substring(15, 24);

            }
            else if (pos == 15 && (key >= 96 && key <= 105 || key >= 48 && key <= 57)) {
                ctrl.value = ctrl.value.toString().substring(0, 15) + tecla + ctrl.value.toString().substring(16, 24);

                brinko = 2;
            }
            else if (pos == 17 && (key >= 96 && key <= 101 || key >= 48 && key <= 53)) {
                ctrl.value = ctrl.value.toString().substring(0, 17) + tecla + ctrl.value.toString().substring(18, 24);

            }
            else if (pos == 18 && (key >= 96 && key <= 105 || key >= 48 && key <= 57)) {
                ctrl.value = ctrl.value.toString().substring(0, 18) + tecla + ctrl.value.toString().substring(19, 24);

                brinko = 2;
            }
            else if (pos >= 19 && (key == 65 || key == 80)) {

                ctrl.value = ctrl.value.toString().substring(0, 20) + tecla.toString().toLowerCase() + ".m."
                brinko = 0;

            }
            else {
                brinko = 0;
            }


            ///////////////////
            if (document.selection) {//iexplorer

                range = ctrl.createTextRange();


                range.move('character', pos + brinko);


                range.select();


                ctrl.defaultValue = ctrl.value;
                window.event.returnValue = false;
            } else if (typeof ctrl.selectionStart != 'undefined') {//others
                ctrl.setSelectionRange(pos + brinko, pos + brinko);
                ctrl.defaultValue = ctrl.value;
            }





        }


        function Flechas(key) {
            var ctrl =
 document.getElementById("TxtFechaHora");
            var saveText = ctrl.value;
            ctrl.focus();

            //////////////////////////////////////
            var range;
            var specialchar = String.fromCharCode(1);
            var $before, $after, $selection;
            var pos;
            var temp;
            //////////////////////////////////////
            if (document.selection) {//iexplorer

                range = document.selection.createRange();
                range.text = specialchar;
                pos = ctrl.value.indexOf(specialchar);
                ctrl.value = saveText;
                range = ctrl.createTextRange();
                range.move('character', pos);
                range.select();
            } else if (typeof ctrl.selectionStart != 'undefined') {//others


                pos = ctrl.selectionStart;
                ctrl.value = saveText;
            }
            if (pos >= 0 && pos <= 2) {

                //Dia++
                var sec = ctrl.value.toString().substring(0, 2)




                if (key == 38) {//Arriba Dia
                    sec = parseInt(sec, 10) + 1;

                    if (ctrl.value.toString().substring(0, 2) < 31) {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = sec + ctrl.value.toString().substring(2, 24)
                        temp = ctrl.value;

                    }
                    else {
                        sec = "01"
                        ctrl.value = "01" + ctrl.value.toString().substring(2, 24)
                        temp = ctrl.value;
                    }
                }
                if (key == 40) {//Abajo dia
                    sec = parseInt(sec, 10) - 1;

                    if (ctrl.value.toString().substring(0, 2) > 1) {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = sec + ctrl.value.toString().substring(2, 24)
                        temp = ctrl.value;

                    }
                    else {
                        sec = "31"
                        ctrl.value = "31" + ctrl.value.toString().substring(2, 24)
                        temp = ctrl.value;

                    }
                }

                var cal = $find("CalendarExtender1");

                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));

                cal._selectedDate = sundayDate;

                cal.set_selectedDate(sundayDate);

                ctrl.value = temp;
                //Dia --


            }

            else if (pos >= 3 && pos <= 5) {

                //Mes++
                var sec = ctrl.value.toString().substring(3, 5)




                if (key == 38) {//Arriba mes
                    sec = parseInt(sec, 10) + 1;

                    if (ctrl.value.toString().substring(3, 5) < 12) {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = ctrl.value.toString().substring(0, 3) + sec + ctrl.value.toString().substring(5, 24)
                        temp = ctrl.value;

                    }
                    else {
                        sec = "01"
                        ctrl.value = ctrl.value.toString().substring(0, 3) + "01" + ctrl.value.toString().substring(5, 24)
                        temp = ctrl.value;
                    }
                }

                if (key == 40) {//Abajo mes
                    sec = parseInt(sec, 10) - 1;

                    if (ctrl.value.toString().substring(3, 5) > 1) {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = ctrl.value.toString().substring(0, 3) + sec + ctrl.value.toString().substring(5, 24)
                        temp = ctrl.value;

                    }
                    else {
                        sec = "12"
                        ctrl.value = ctrl.value.toString().substring(0, 3) + "12" + ctrl.value.toString().substring(5, 24)
                        temp = ctrl.value;

                    }
                }


                var cal = $find("CalendarExtender1");





                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));

                cal._selectedDate = sundayDate;

                cal.set_selectedDate(sundayDate);

                ctrl.value = temp;
                //Mes --


            }
            else if (pos >= 6 && pos <= 10) {

                //Año++
                var sec = ctrl.value.toString().substring(6, 10)




                if (key == 38) {//Arriba Año
                    sec = parseInt(sec, 10) + 1;

                    if (ctrl.value.toString().substring(6, 10) < 2015) {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = ctrl.value.toString().substring(0, 6) + sec + ctrl.value.toString().substring(10, 24)
                        temp = ctrl.value;

                    }
                    else {
                        sec = "2000"
                        ctrl.value = ctrl.value.toString().substring(0, 6) + "2000" + ctrl.value.toString().substring(10, 24)
                        temp = ctrl.value;
                    }
                }

                if (key == 40) {//Abajo Año
                    sec = parseInt(sec, 10) - 1;

                    if (ctrl.value.toString().substring(6, 10) > 2000) {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = ctrl.value.toString().substring(0, 6) + sec + ctrl.value.toString().substring(10, 24)
                        temp = ctrl.value;

                    }
                    else {
                        sec = "2015"
                        ctrl.value = ctrl.value.toString().substring(0, 6) + "2015" + ctrl.value.toString().substring(10, 24)
                        temp = ctrl.value;

                    }
                }


                var cal = $find("CalendarExtender1");





                sundayDate = new Date(ctrl.value.toString().substring(6, 10), ctrl.value.toString().substring(3, 5) - 1, ctrl.value.toString().substring(0, 2));

                cal._selectedDate = sundayDate;

                cal.set_selectedDate(sundayDate);

                ctrl.value = temp;
                //Año --


            }
            else if (pos >= 11 && pos <= 13) {

                //Horas++
                var sec = ctrl.value.toString().substring(11, 13)


                if (key == 38) {//Arriba Horas
                    sec = parseInt(sec, 10) + 1;

                    if (ctrl.value.toString().substring(11, 13) < 12) {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = ctrl.value.toString().substring(0, 11) + sec + ctrl.value.toString().substring(13, 24)


                    }
                    else {
                        sec = "01"
                        ctrl.value = ctrl.value.toString().substring(0, 11) + "01" + ctrl.value.toString().substring(13, 24)
                    }
                }

                if (key == 40) {//Abajo Horas
                    sec = parseInt(sec, 10) - 1;

                    if (ctrl.value.toString().substring(11, 13) > "01") {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = ctrl.value.toString().substring(0, 11) + sec + ctrl.value.toString().substring(13, 24)


                    }
                    else {
                        sec = "12"
                        ctrl.value = ctrl.value.toString().substring(0, 11) + "12" + ctrl.value.toString().substring(13, 24)
                    }
                }
                //Horas --


            }
            else if (pos >= 14 && pos <= 16) {

                //Minutos++
                var sec = ctrl.value.toString().substring(14, 16)


                if (key == 38) {//Arriba Minutos
                    sec = parseInt(sec, 10) + 1;

                    if (ctrl.value.toString().substring(14, 16) < 59) {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = ctrl.value.toString().substring(0, 14) + sec + ctrl.value.toString().substring(16, 24)


                    }
                    else {
                        sec = "00"
                        ctrl.value = ctrl.value.toString().substring(0, 14) + "00" + ctrl.value.toString().substring(16, 24)
                    }
                }

                if (key == 40) {//Abajo Minitos
                    sec = parseInt(sec, 10) - 1;

                    if (ctrl.value.toString().substring(14, 16) > "00") {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = ctrl.value.toString().substring(0, 14) + sec + ctrl.value.toString().substring(16, 24)


                    }
                    else {
                        sec = "59"
                        ctrl.value = ctrl.value.toString().substring(0, 14) + "59" + ctrl.value.toString().substring(16, 24)
                    }
                }
                //MINITOS --

            }
            else if (pos >= 17 && pos <= 19) {

                var sec = ctrl.value.toString().substring(17, 19)


                if (key == 38) {//Arriba 
                    sec = parseInt(sec, 10) + 1;

                    if (ctrl.value.toString().substring(17, 19) < 59) {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = ctrl.value.toString().substring(0, 17) + sec + ctrl.value.toString().substring(19, 24)


                    }
                    else {
                        sec = "00"
                        ctrl.value = ctrl.value.toString().substring(0, 17) + "00" + ctrl.value.toString().substring(19, 24)
                    }
                }

                if (key == 40) {//Abajo
                    sec = parseInt(sec, 10) - 1;

                    if (ctrl.value.toString().substring(17, 19) > "00") {

                        if (sec.toString().length == 1) {
                            sec = "0" + sec.toString();
                        }

                        ctrl.value = ctrl.value.toString().substring(0, 17) + sec + ctrl.value.toString().substring(19, 24)


                    }
                    else {
                        sec = "59"
                        ctrl.value = ctrl.value.toString().substring(0, 17) + "59" + ctrl.value.toString().substring(19, 24)
                    }
                }


            }
            else if (pos >= 20 && pos <= 24) {
                if (ctrl.value.toString().substring(20, 24) == "a.m.") {
                    ctrl.value = ctrl.value.toString().substring(0, 20) + "p.m."


                }
                else {
                    ctrl.value = ctrl.value.toString().substring(0, 20) + "a.m."
                }
            }


            if (document.selection) {//iexplorer

                range = ctrl.createTextRange();


                range.move('character', pos);


                range.select();


                ctrl.defaultValue = ctrl.value;
                window.event.returnValue = false;
            } else if (typeof ctrl.selectionStart != 'undefined') {//others
                ctrl.setSelectionRange(pos, pos);
                ctrl.defaultValue = ctrl.value;
            }




        }


        
    </script>

</head>
<body id="Page" style="background-image: url('images/amesol_duxtar.jpg'); background-attachment: fixed;
    background-repeat: no-repeat; background-position: bottom right">
    <form id="form1" runat="server">
    <table style="height: 100%; width: 100%">
        <tr>
            <td style="vertical-align: top">
                <div>
                    <center>
                        <img alt="" src="images/logo_amesol_horizontal.jpg" />
                        <br />
            <a href="Default.aspx">
                <img style="border: 0" alt="" src="images/home.png" /></a>
            <br />
                    </center>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanelRepetidor" runat="server" UpdateMode="Always" RenderMode="Inline">
                        <ContentTemplate>
                            <center>
                                <asp:Panel ID="pnlEdicion" runat="server">
                                    <asp:TextBox ID="TxtDiaTrabajo" runat="server" OnTextChanged="TxtDiaTrabajo_TextChanged"
                                        AutoPostBack="true" />
                                    <cc1:CalendarExtender runat="server" ID="CalendarExtenderDiaTrabajo" TargetControlID="TxtDiaTrabajo"
                                        Format="dd/MM/yyyy" OnClientDateSelectionChanged="CambioDiaTrabajo">
                                    </cc1:CalendarExtender>
                                    <asp:DropDownList ID="ComboUsuario" runat="server" OnSelectedIndexChanged="ComboUsuario_SelectedIndexChanged"
                                        AutoPostBack="true" />
                                    <br />
                                    <br />
                                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                                        OnItemCreated="Repeater1_ItemCreated">
                                        <HeaderTemplate>
                                            <table id="sample">
                                                <tr style="background-image: url('images/fondoo.gif'); background-repeat: repeat-x;
                                                    color: White" runat="server">
                                                    <th style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                        <asp:Label ID="Label1" runat="server" Text="Fecha Hora"></asp:Label>
                                                    </th>
                                                    <th style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                        <asp:Label ID="Label2" runat="server" Text="Tipo"></asp:Label>
                                                    </th>
                                                    <th style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                        <asp:Label ID="Label3" runat="server" Text="Cliente"></asp:Label>
                                                    </th>
                                                    <th style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                        <asp:Label ID="Label7" runat="server" Text="Area"></asp:Label>
                                                    </th>
                                                    <th style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                        <asp:Label ID="Label6" runat="server" Text="Actividad"></asp:Label>
                                                    </th>
                                                    <th style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                        <asp:Label ID="Label5" runat="server" Text="Horas"></asp:Label>
                                                    </th>
                                                    <th style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                        <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label>
                                                    </th>
                                                    <th align="left" width="80px" id="Guardar" style="background-image: none; background-color: White">
                                                    </th>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr id="FILA" runat="server">
                                                <td id="FechaHoraInicial" style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                    <asp:Label ID="lblFechaHoraInicial" runat="server" Text='<%# (Eval("FechaHoraInicial")).ToString() %>'></asp:Label>
                                                </td>
                                                <td id="Proyecto" style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                    <asp:Label ID="lblProyecto" runat="server" Text='<%# (Eval("Proyecto")).ToString() %>'></asp:Label>
                                                </td>
                                                <td id="Cliente" style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                    <asp:DropDownList ID="comboCliente" AutoPostBack="true" OnSelectedIndexChanged="ComboCliente_SelectedIndexChanged"
                                                        Enabled='<%#Eval("PValor")%>' Visible='<%#Eval("PValor")%>' BorderStyle="None"
                                                        DataSource="<%# Clientes %>" DataTextField="Descripcion" DataValueField="Clave"
                                                        SelectedValue='<%#Eval("CValor")!= null?Eval("CValor"):Guid.Empty%>' runat="server" />
                                                </td>
                                                <td id="Td2" style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                    <asp:DropDownList ID="comboArea" AutoPostBack="true" OnSelectedIndexChanged="ComboCliente_SelectedIndexChanged"
                                                        Enabled='<%#Eval("PValor")%>' Visible='<%#Eval("PValor")%>' DataSource='<%#Areas%>'
                                                        SelectedValue='<%#Eval("ArValor")!= null?Eval("ArValor"):Guid.Empty%>' BorderStyle="None"
                                                        DataTextField="Descripcion" DataValueField="Clave" runat="server" />
                                                </td>
                                                <td id="Td1" style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                    <asp:DropDownList ID="comboActividad" AutoPostBack="true" OnSelectedIndexChanged="ComboCliente_SelectedIndexChanged"
                                                        Enabled='<%#Eval("PValor")%>' Visible='<%#Eval("PValor")%>' DataSource='<%#Actividades%>'
                                                        SelectedValue='<%#Eval("AValor")!= null?Eval("AValor"):Guid.Empty%>' BorderStyle="None"
                                                        DataTextField="Descripcion" DataValueField="Clave" runat="server" />
                                                </td>
                                                <td id="Horas" style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox AutoPostBack="true" OnTextChanged="TxtHoraRepeater_TextChanged" ID="txtControl"
                                                                    runat="server" Visible='<%#Eval("PValor")%>' Width="25px" Text='<%# (Eval("Horas")).ToString() %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td id="Descripcion" style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                    <asp:TextBox AutoPostBack="true" OnTextChanged="TxtDescripcionRepeater_TextChanged"
                                                        ID="txtDescripcionR" onpropertychange="TecleoIE(event);" onkeyup="TecleoFX(event);"
                                                        runat="server" BorderStyle="None" Text='<%# (Eval("Descripcion")).ToString() %>'></asp:TextBox>
                                                </td>
                                                <td align="left" width="80px" id="Guardar" style="background-image: none; background-color: White">
                                                    <asp:ImageButton ToolTip="Guardar Cambios" Visible="false" ID="btnGuardar" runat="server"
                                                        ImageUrl="~/images/button_ok.png" CommandName="Guardar" CommandArgument='<%# ((DateTime)Eval("FechaHoraInicial")).ToString("yyyy-MM-ddTHH:mm:ss.fffffff") %>' />
                                                    <asp:ImageButton ToolTip="Borrar Registro" ID="btnEliminar" runat="server" ImageUrl="~/images/button_cancel.png"
                                                        CommandName="Eliminar" CommandArgument='<%# ((DateTime)Eval("FechaHoraInicial")).ToString("yyyy-MM-ddTHH:mm:ss.fffffff") %>' />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr id="FILA" runat="server">
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:TextBox BorderStyle="None" ID="TxtFechaHora" runat="server" Width="180px" EnableViewState="true"
                                                onkeydown="var key = event.keyCode; if (key == 38 || key == 40) {Flechas(key);}else if ((key >= 96 && key <= 105 || key >= 48 && key <= 57 || key == 65 || key == 80)) {Numeros(key);}else if (key == 8) {Borrar();};" />
                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="TxtFechaHora"
                                                OnClientDateSelectionChanged="CambioFecha" Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:DropDownList ID="comboProyecto" AutoPostBack="true" DataSource="<%#TipoTiempos%>"
                                                BorderStyle="None" DataTextField="Descripcion" DataValueField="Clave" runat="server"
                                                OnSelectedIndexChanged="comboProyecto_SelectedIndexChanged" />
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:DropDownList ID="comboClienteFuera"  DataSource="<%#Clientes%>"
                                                BorderStyle="None" DataTextField="Descripcion" DataValueField="Clave" runat="server" />
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:DropDownList ID="comboAreaFuera"  DataSource="<%#Areas%>"
                                                BorderStyle="None" DataTextField="Descripcion" DataValueField="Clave" runat="server" />
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:DropDownList ID="comboActividadFuera"  DataSource="<%#Actividades%>"
                                                BorderStyle="None" DataTextField="Descripcion" DataValueField="Clave" runat="server" />
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox AutoPostBack="true" ID="txtHoras" runat="server" Width="25px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:TextBox BorderStyle="None" ID="TxtDescripcion" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="left" width="80px" id="Guardar" style="background-image: none; background-color: White">
                                            <asp:Button ID="btAceptar" runat="server" Text="Guardar" OnClick="BtGuardar_Click" />
                                        </td>
                                    </tr>
                                    </table>
                                </asp:Panel>
                                <br />
                                <br />
                                <asp:Label ID="lblNoSeEdita" runat="server" Text="No cuentas con los permisos necesarios para la edicion de tiempos"
                                    Visible="False" ForeColor="Red"></asp:Label>
                            </center>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        
    </table>
    </form>
</body>
</html>
