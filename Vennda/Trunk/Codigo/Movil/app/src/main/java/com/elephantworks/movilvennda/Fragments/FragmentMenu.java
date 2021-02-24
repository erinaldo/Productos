package com.elephantworks.movilvennda.Fragments;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;

import com.elephantworks.movilvennda.Interfaces.IProductosVentas;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.R;

/**
 * Created by ldelatorre on 10/06/2017.
 */
public class FragmentMenu extends FragmentStatePagerAdapter {
    int mNumOfTabs;
    FragmentManager fma;

    public FragmentMenu(FragmentManager fm, int NumOfTabs) {
        super(fm);
        this.fma = fm;
        this.mNumOfTabs = NumOfTabs;
    }

    @Override
    public Fragment getItem(int position) {
        switch (position) {
            case 0:
                FragmentVentas tabVentas = new FragmentVentas();
                return tabVentas;
            case 1:
                FragmentProductos tabProductos = new FragmentProductos();
                return tabProductos;
            default:
                return null;
        }
    }

    @Override
    public int getCount() {
        return mNumOfTabs;
    }
}
