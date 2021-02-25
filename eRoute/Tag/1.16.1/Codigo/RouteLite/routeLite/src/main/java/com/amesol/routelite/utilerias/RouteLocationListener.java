package com.amesol.routelite.utilerias;

import android.location.Location;

/**
 * Created by Adriana on 05/06/2017.
 */
public interface RouteLocationListener {
    public void updateLocation(Location location);
    public void begingLocation(boolean bDisponible);
}
