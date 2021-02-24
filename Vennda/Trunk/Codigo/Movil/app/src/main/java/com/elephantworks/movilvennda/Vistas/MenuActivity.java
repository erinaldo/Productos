package com.elephantworks.movilvennda.Vistas;

import android.Manifest;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.os.StrictMode;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.design.widget.TabLayout;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.content.ContextCompat;
import android.support.v4.content.FileProvider;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.elephantworks.movilvennda.BuildConfig;
import com.elephantworks.movilvennda.Fragments.FragmentListadoCategorias;
import com.elephantworks.movilvennda.Fragments.FragmentMenu;
import com.elephantworks.movilvennda.Fragments.FragmentProductos;
import com.elephantworks.movilvennda.Interfaces.IMenu;
import com.elephantworks.movilvennda.Interfaces.IProductosVentas;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.Presentadora.PresentadorAsyncTask;
import com.elephantworks.movilvennda.Presentadora.PresentadorMenu;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;

import static android.os.Environment.getExternalStorageDirectory;

public class MenuActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener, IMenu {

    private TextView lblMenuLateralNombre;
    private TextView lblMenuLateralCorreo;
    private PresentadorMenu mPresenta;
    private Context context = MenuActivity.this;
    private ProgressDialog progressDialog;
    /*private static final int REQUEST_CODE = 100;
    private static String[] PERMISSIONS_STORAGE = {
            Manifest.permission.READ_EXTERNAL_STORAGE,
            Manifest.permission.WRITE_EXTERNAL_STORAGE
    };
    private static final int PERMISSION_REQUEST_CODE = 100;

*/
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

       /* FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });*/

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        /*Mi codigo*/
        this.inicializar(navigationView);
        mPresenta = new PresentadorMenu(context, this);
        //Validar la conectividad a Internet
        ConnectivityManager connMgr = (ConnectivityManager)
                getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo networkInfo = connMgr.getActiveNetworkInfo();

        if (android.os.Build.VERSION.SDK_INT > 9) {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
        }
        mPresenta.llenarTextos();
    }


    public void inicializar(NavigationView navigationView){

        View headerView = navigationView.getHeaderView(0);
        lblMenuLateralNombre = (TextView) headerView.findViewById(R.id.lblMenuLateralNombre);
        lblMenuLateralCorreo = (TextView) headerView.findViewById(R.id.lblMenuLateralCorreo);


        TabLayout tabLayout = (TabLayout) findViewById(R.id.tab_menu_layout);
        tabLayout.addTab(tabLayout.newTab().setText(context.getString(R.string.tabVentas)));
        tabLayout.addTab(tabLayout.newTab().setText(context.getString(R.string.tabProductos)));
        tabLayout.setTabGravity(TabLayout.GRAVITY_CENTER);

        final ViewPager viewPager = (ViewPager) findViewById(R.id.pager_menu);
        final FragmentMenu adapter = new FragmentMenu(getSupportFragmentManager(), tabLayout.getTabCount());
        viewPager.setAdapter(adapter);
        viewPager.addOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(tabLayout));
        tabLayout.setOnTabSelectedListener(new TabLayout.OnTabSelectedListener() {
            @Override
            public void onTabSelected(TabLayout.Tab tab) {
                viewPager.setCurrentItem(tab.getPosition());
            }

            @Override
            public void onTabUnselected(TabLayout.Tab tab) {

            }

            @Override
            public void onTabReselected(TabLayout.Tab tab) {

            }
        });

    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        if (id == R.id.nav_camera) {
            //Codigo de apertura de caja
            Intent i = new Intent(MenuActivity.this, AperturaCierreActivity.class);
            i.putExtra("apertura", true);
            i.putExtra("vieneDePuntoVenta", true);
            startActivity(i);
            // Handle the camera action
        } else if (id == R.id.nav_gallery) {
            Intent i = new Intent(MenuActivity.this,ClienteActivity.class);
            startActivity(i);

        } else if (id == R.id.nav_slideshow) {

            Intent i = new Intent(MenuActivity.this,ConsultarVentas.class);
            startActivity(i);

        } else if (id == R.id.nav_share) {
            Intent i = new Intent(MenuActivity.this, AperturaCierreActivity.class);
            i.putExtra("apertura", false);
            startActivity(i);
            this.finish();

        } else if(id == R.id.nav_configuration){
            Intent i = new Intent(MenuActivity.this, ConfiguracionActivity.class);
            startActivity(i);

        }else if (id == R.id.nav_send) {

        }else if(id == R.id.nav_devolucion ){
            this.mostrarDialogBuscarTicket();
        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }


    @Override
    public void llenarTextosVista(String nombre, String correo) {
        lblMenuLateralNombre.setText(nombre);
        lblMenuLateralCorreo.setText(correo);
    }

    @Override
    public void mostrarProgreso(String mensaje) {
        progressDialog = new ProgressDialog(this);
        progressDialog.setMessage(mensaje);
        progressDialog.show();

    }

    @Override
    public void cambiarMensajeProgreso(String mensaje) {
        progressDialog.setMessage(mensaje);
    }

    @Override
    public void cerrarProgeso() {
        progressDialog.dismiss();
    }

    @Override
    public void mostrarError(String error) {
        MetodosEstaticos.AlertDialogSimple(context, error);
    }

    public void iniciarBillPocket(Intent intent){
        startActivityForResult(intent, Constantes.BillPocket.CREDIT_CARD_INTENT);
    }

    public void mostrarDialogBuscarTicket(){

        LayoutInflater inflater = this.getLayoutInflater();
        View dialoglayout = inflater.inflate(R.layout.dialogo_buscar_ticket, null);
        final AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setView(dialoglayout);
        final AlertDialog dialog = builder.show();


        Button btnAceptar = (Button) dialoglayout.findViewById(R.id.btnAceptarDevolucionDlg);
        final EditText etFolio = (EditText) dialoglayout.findViewById(R.id.etTicketBT);

        btnAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String folio = etFolio.getText().toString();
                if(!folio.equals("")){
                   String mensaje =  mPresenta.buscarTicket(folio);
                    if(!mensaje.equals("")){
                        MetodosEstaticos.AlertDialogSimple(context, mensaje);
                    }else {
                        Intent i = new Intent(MenuActivity.this, DevolucionActivity.class);
                        startActivity(i);
                        dialog.dismiss();
                    }
                }else {
                    MetodosEstaticos.AlertDialogSimple(context, "Es necesario ingresar el folio.");
                }

            }
        });

    }


}
