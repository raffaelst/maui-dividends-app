# maui-dividends-app

# Stock Market Tracker App

Overview

The Stock Market Tracker App is a cross-platform mobile application built using .NET MAUI. It displays the latest prices of major US stocks in real-time and allows users to click on any stock to view its dividend history. This app is designed to demonstrate the ability to work with APIs, manage navigation between pages, and present financial information in an accessible way.

Features

Real-Time Stock Prices: Displays a list of important US stocks (e.g., AAPL, MSFT, GOOGL, etc.) with their current prices.

Dividend History: Allows users to click on a stock to view its historical dividend data.

Cross-Platform Compatibility: Runs on Android, iOS, Windows, and macOS using a single codebase.

Getting Started

Follow the instructions below to set up and run the project.

Prerequisites

Visual Studio 2022 with the Mobile Development with .NET workload installed.

.NET MAUI environment set up.

An API key from Alpha Vantage to get stock data.

Installation

Clone the Repository:

git clone 
cd StockMarketTracker

Open the Project in Visual Studio:

Open Visual Studio 2022.

Click Open a project or solution and navigate to the project directory.

Install Dependencies:

Right-click on the solution in Solution Explorer.

Select Manage NuGet Packages.

Ensure Newtonsoft.Json and System.Net.Http are installed.

Add Your API Key:

Replace "YOUR_ALPHA_VANTAGE_API_KEY" in MainPage.xaml.cs and DividendPage.xaml.cs with your Alpha Vantage API key.

Running the App

Select a Target Platform (e.g., Android, iOS, Windows).

Click the Run button (green triangle) to start the app.

If you're targeting Android, ensure you have an emulator running or connect a physical Android device.

Usage

View Stock Prices: The main page displays a list of major US stocks with their current prices.

View Dividend History: Click on any stock to view its historical dividend payments. The dividend history is fetched from the Alpha Vantage API and displayed in a list format.

Refresh Data: Press the Refresh button to update stock prices in real-time.

Project Structure

MainPage.xaml: The main UI that displays the list of stocks and the refresh button.

MainPage.xaml.cs: Contains the logic for fetching and displaying stock data.

DividendPage.xaml: UI for displaying dividend history for a selected stock.

DividendPage.xaml.cs: Contains the logic for fetching and displaying dividend data.

API Integration

This project uses the Alpha Vantage API to get stock and dividend information.

Global Quote Endpoint: Fetches the latest price for individual stocks.

Time Series Monthly Adjusted Endpoint: Fetches historical dividend data for stocks.

Screenshots

Main Page: Displays the list of stocks and their current prices.

Dividend Page: Displays historical dividend information for a selected stock.

Possible Improvements

Polish the UI to make it visually more appealing, such as adding icons or graphs.

Add Loading Indicators to inform users when data is being fetched.

Add Caching to avoid unnecessary API calls.

Add Real-Time Updates: Set up a timer to automatically refresh stock prices at a set interval.

License

This project is licensed under the MIT License. See the LICENSE file for details.

Acknowledgments

Alpha Vantage for providing free financial market data.

.NET MAUI for enabling cross-platform app development with a single codebase.
