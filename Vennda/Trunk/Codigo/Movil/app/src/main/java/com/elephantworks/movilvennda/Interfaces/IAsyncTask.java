package com.elephantworks.movilvennda.Interfaces;

/**
 * Created by ldelatorre on 29/05/2017.
 */
public interface IAsyncTask {
    void before();
    String toDo();
    void after(String result);

}
