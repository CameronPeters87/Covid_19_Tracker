# Covid-19 Live Stat Tracker

## 📌 Overview

The **Covid-19 Live Stat Tracker** is an MVC web application that provides **real-time coronavirus statistics**. The app fetches live data via a **RESTful API** and displays global and South African Covid-19 statistics on a single-page dashboard.

The application also integrates **Google Maps API** to visualize the geolocation of affected countries and display a **heatmap** highlighting regions with high case counts.

---

## 🚀 Features

* 🌍 **Live Covid-19 statistics** for South Africa and globally
* 🗺️ **Interactive Google Maps heatmap** showing affected regions
* 📊 **Real-time updates** via RESTful API calls
* 💻 **Responsive single-page design** for desktop and mobile
* 🔹 Clean and user-friendly interface

---

## 🛠️ Tech Stack

* **Framework:** .NET Framework (MVC)
* **Language:** C#
* **Database:** None (data fetched directly from REST API)
* **APIs:** RESTful Covid-19 data API, Google Maps API
* **IDE:** Visual Studio
* **UI:** Razor Views + Bootstrap

---

## 📂 Project Structure

```
project-root/
│── Controllers/       # Handles API requests and logic
│── Models/            # Data models for API response
│── Views/             # Razor Views for UI
│── Scripts/           # JavaScript for maps & heatmap
│── Content/           # CSS, images, assets
│── README.md          # Project overview
```

---

## 🔧 Installation & Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/Covid_19_Tracker.git
   ```
2. Open the solution in **Visual Studio**.
3. Ensure you have a valid **Google Maps API key** and update it in the configuration or JS file.
4. Run the application (`F5`) to build and launch.

---

## 🎯 Usage

* Visit the app to view **real-time Covid-19 statistics**.
* Explore the **heatmap** to see the global distribution of cases.
* Zoom in/out on the map to view country-specific information.

* <img width="1919" height="913" alt="image" src="https://github.com/user-attachments/assets/4e223c7f-5250-4d71-805f-f448956ee525" />


---

## 📖 Future Improvements

* Add filtering by date or region
* Include historical trend graphs
* Implement additional statistics like recoveries and vaccinations
* Add dark mode for better visualization

---

## 👩‍💻 Author

*Developed by Cameron Peters* as a learning project using **MVC .NET Framework** with **REST API integration** and **Google Maps visualization**.
