package com.amesol.routelite.vistas.generico;

/*
import java.util.Arrays;
import java.util.LinkedList;

import com.amesol.routelite.presentadores.interfaces.IPullRefresh;
import com.amesol.routelite.views.R;
import com.markupartist.android.widget.PullToRefreshListView;
import com.markupartist.android.widget.PullToRefreshListView.OnRefreshListener;

import android.annotation.SuppressLint;
import android.app.ListActivity;
import android.os.AsyncTask;
import android.os.Bundle;
*/

public class PullToRefresh
{
	/*
	IPullRefresh mPulling;
	private LinkedList<String> mListItems;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		// setContentView(R.layout.pull_to_refresh);
		setContentView(R.layout.pull_to_refresh);
		// Set a listener to be invoked when the list should be refreshed.
		((PullToRefreshListView) getListView()).setOnRefreshListener(new OnRefreshListener()
		{
			@Override
			public void onRefresh()
			{
				// Do work to refresh the list here.
				new GetDataTask().execute();
			}
		});

		mListItems = new LinkedList<String>();
		mListItems.addAll(Arrays.asList(mStrings));
	}

	@SuppressLint("NewApi")
	private class GetDataTask extends AsyncTask<Void, Void, String[]>
	{

		@Override
		protected String[] doInBackground(Void... params)
		{
			// Simulates a background job.
			try
			{
				Thread.sleep(2000);
				mPulling.PullingToRefech();
			}
			catch (InterruptedException e)
			{
				;
			}
			return mStrings;
		}

		@Override
		protected void onPostExecute(String[] result)
		{
			mListItems.addFirst("Added after refresh...");

			// Call onRefreshComplete when the list has been refreshed.
			((PullToRefreshListView) getListView()).onRefreshComplete();

			super.onPostExecute(result);
		}
	}

	private String[] mStrings =
	{ "Abbaye de Belloc", "Abbaye du Mont des Cats" };
	*/
}
