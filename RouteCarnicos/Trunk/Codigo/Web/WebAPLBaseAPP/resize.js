// JScript File
if(navigator.appName == "Netscape" || (typeof(opera) != "undefined" && parseFloat(opera.version()) >= 9) || navigator.vendor == "Apple Computer, Inc." || navigator.vendor == "KDE")
{    
    window.addEventListener("load",resizeElement,true);
    window.addEventListener("resize",resizeElement,true);
}

function resizeElement()
{    
    if(document.body != null)
    {
        try
        {
            var x = document.body.clientHeight - 38;          
            var t = document.body.getElementsByTagName("TABLE")[0];     
            var h = 0;
            var xr = null; 
            if(t != null && t.rows != null)
            {
                t.style.height = ""; 
                for(var i=0;i<t.rows.length;i++)
                {
                    var r = t.rows[i]; 
                    if(r.getAttribute("id") != "xr")
                        h += r.offsetHeight;        
                    else
                        xr = r; 
                }        
                xr.cells[0].style.height = (x-h);                 
            }
        }
        catch(xx) 
        { } 
    }
}



