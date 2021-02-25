package com.selling.movil.interfaces;

/**
 * Created by Eduardo on 02/10/15.
 */
public interface AsyncTaskInterface {

    void before();
    String toDo();
    void after(String result);
}
