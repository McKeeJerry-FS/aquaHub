// Tank Dashboard Charts using Chart.js
window.renderTankCharts = function (data) {
  // Destroy existing charts to prevent memory leaks
  const chartIds = [
    "phChart",
    "temperatureChart",
    "nitrogenChart",
    "reefChart",
    "hardnessChart",
  ];

  chartIds.forEach((id) => {
    const canvas = document.getElementById(id);
    if (canvas) {
      const existingChart = Chart.getChart(canvas);
      if (existingChart) {
        existingChart.destroy();
      }
    }
  });

  // pH Chart
  const phCtx = document.getElementById("phChart");
  if (phCtx && data.phData && data.phData.length > 0) {
    new Chart(phCtx, {
      type: "line",
      data: {
        labels: data.labels,
        datasets: [
          {
            label: "pH Level",
            data: data.phData,
            borderColor: "#4facfe",
            backgroundColor: "rgba(79, 172, 254, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            pointRadius: 4,
            pointHoverRadius: 6,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: true,
        interaction: {
          mode: "index",
          intersect: false,
        },
        plugins: {
          legend: {
            display: true,
            position: "top",
          },
          tooltip: {
            backgroundColor: "rgba(0, 0, 0, 0.8)",
            padding: 12,
            callbacks: {
              label: function (context) {
                return "pH: " + context.parsed.y.toFixed(1);
              },
            },
          },
        },
        scales: {
          x: {
            grid: {
              display: false,
            },
          },
          y: {
            beginAtZero: false,
            min: 6,
            max: 9,
            title: {
              display: true,
              text: "pH Level",
            },
          },
        },
      },
    });
  }

  // Temperature Chart
  const tempCtx = document.getElementById("temperatureChart");
  if (tempCtx && data.temperatureData && data.temperatureData.length > 0) {
    new Chart(tempCtx, {
      type: "line",
      data: {
        labels: data.labels,
        datasets: [
          {
            label: "Temperature (°F)",
            data: data.temperatureData,
            borderColor: "#ff6b6b",
            backgroundColor: "rgba(255, 107, 107, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            pointRadius: 4,
            pointHoverRadius: 6,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: true,
        interaction: {
          mode: "index",
          intersect: false,
        },
        plugins: {
          legend: {
            display: true,
            position: "top",
          },
          tooltip: {
            backgroundColor: "rgba(0, 0, 0, 0.8)",
            padding: 12,
            callbacks: {
              label: function (context) {
                return "Temperature: " + context.parsed.y.toFixed(1) + "°F";
              },
            },
          },
        },
        scales: {
          x: {
            grid: {
              display: false,
            },
          },
          y: {
            beginAtZero: false,
            min: 70,
            max: 85,
            title: {
              display: true,
              text: "Temperature (°F)",
            },
          },
        },
      },
    });
  }

  // Nitrogen Cycle Chart
  const nitrogenCtx = document.getElementById("nitrogenChart");
  if (nitrogenCtx) {
    new Chart(nitrogenCtx, {
      type: "line",
      data: {
        labels: data.labels,
        datasets: [
          {
            label: "Ammonia (ppm)",
            data: data.ammoniaData,
            borderColor: "#ffd93d",
            backgroundColor: "rgba(255, 217, 61, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            pointRadius: 4,
            pointHoverRadius: 6,
          },
          {
            label: "Nitrite (ppm)",
            data: data.nitriteData,
            borderColor: "#ff9a3c",
            backgroundColor: "rgba(255, 154, 60, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            pointRadius: 4,
            pointHoverRadius: 6,
          },
          {
            label: "Nitrate (ppm)",
            data: data.nitrateData,
            borderColor: "#66bb6a",
            backgroundColor: "rgba(102, 187, 106, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            pointRadius: 4,
            pointHoverRadius: 6,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: true,
        interaction: {
          mode: "index",
          intersect: false,
        },
        plugins: {
          legend: {
            display: true,
            position: "top",
          },
          tooltip: {
            backgroundColor: "rgba(0, 0, 0, 0.8)",
            padding: 12,
            callbacks: {
              label: function (context) {
                return (
                  context.dataset.label +
                  ": " +
                  context.parsed.y.toFixed(2) +
                  " ppm"
                );
              },
            },
          },
        },
        scales: {
          x: {
            grid: {
              display: false,
            },
          },
          y: {
            beginAtZero: true,
            title: {
              display: true,
              text: "Concentration (ppm)",
            },
          },
        },
      },
    });
  }

  // Reef Parameters Chart
  const reefCtx = document.getElementById("reefChart");
  if (reefCtx && data.tankType && (data.tankType === "Reef" || data.tankType === "Saltwater")) {
    new Chart(reefCtx, {
      type: "line",
      data: {
        labels: data.labels,
        datasets: [
          {
            label: "Salinity (ppt)",
            data: data.salinityData,
            borderColor: "#42a5f5",
            backgroundColor: "rgba(66, 165, 245, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            yAxisID: "y-salinity",
            pointRadius: 4,
            pointHoverRadius: 6,
          },
          {
            label: "Alkalinity (dKH)",
            data: data.alkalinityData,
            borderColor: "#ab47bc",
            backgroundColor: "rgba(171, 71, 188, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            yAxisID: "y-alkalinity",
            pointRadius: 4,
            pointHoverRadius: 6,
          },
          {
            label: "Calcium (ppm)",
            data: data.calciumData,
            borderColor: "#66bb6a",
            backgroundColor: "rgba(102, 187, 106, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            yAxisID: "y-calcium",
            hidden: true,
            pointRadius: 4,
            pointHoverRadius: 6,
          },
          {
            label: "Magnesium (ppm)",
            data: data.magnesiumData,
            borderColor: "#ffa726",
            backgroundColor: "rgba(255, 167, 38, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            yAxisID: "y-magnesium",
            hidden: true,
            pointRadius: 4,
            pointHoverRadius: 6,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: true,
        interaction: {
          mode: "index",
          intersect: false,
        },
        plugins: {
          legend: {
            display: true,
            position: "top",
          },
          tooltip: {
            backgroundColor: "rgba(0, 0, 0, 0.8)",
            padding: 12,
          },
        },
        scales: {
          x: {
            grid: {
              display: false,
            },
          },
          "y-salinity": {
            type: "linear",
            display: true,
            position: "left",
            title: {
              display: true,
              text: "Salinity (ppt)",
            },
            min: 30,
            max: 36,
          },
          "y-alkalinity": {
            type: "linear",
            display: true,
            position: "right",
            title: {
              display: true,
              text: "Alkalinity (dKH)",
            },
            min: 7,
            max: 12,
            grid: {
              drawOnChartArea: false,
            },
          },
          "y-calcium": {
            type: "linear",
            display: false,
            min: 350,
            max: 500,
          },
          "y-magnesium": {
            type: "linear",
            display: false,
            min: 1200,
            max: 1500,
          },
        },
      },
    });
  }

  // Freshwater Hardness Chart
  const hardnessCtx = document.getElementById("hardnessChart");
  if (hardnessCtx && data.tankType && (data.tankType === "Freshwater" || data.tankType === "Planted")) {
    new Chart(hardnessCtx, {
      type: "line",
      data: {
        labels: data.labels,
        datasets: [
          {
            label: "GH (°dH)",
            data: data.ghData,
            borderColor: "#66bb6a",
            backgroundColor: "rgba(102, 187, 106, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            yAxisID: "y-hardness",
            pointRadius: 4,
            pointHoverRadius: 6,
          },
          {
            label: "KH (°dH)",
            data: data.khData,
            borderColor: "#42a5f5",
            backgroundColor: "rgba(66, 165, 245, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            yAxisID: "y-hardness",
            pointRadius: 4,
            pointHoverRadius: 6,
          },
          {
            label: "TDS (ppm)",
            data: data.tdsData,
            borderColor: "#ffa726",
            backgroundColor: "rgba(255, 167, 38, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            yAxisID: "y-tds",
            pointRadius: 4,
            pointHoverRadius: 6,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: true,
        interaction: {
          mode: "index",
          intersect: false,
        },
        plugins: {
          legend: {
            display: true,
            position: "top",
          },
          tooltip: {
            backgroundColor: "rgba(0, 0, 0, 0.8)",
            padding: 12,
          },
        },
        scales: {
          x: {
            grid: {
              display: false,
            },
          },
          "y-hardness": {
            type: "linear",
            display: true,
            position: "left",
            title: {
              display: true,
              text: "Hardness (°dH)",
            },
            beginAtZero: true,
          },
          "y-tds": {
            type: "linear",
            display: true,
            position: "right",
            title: {
              display: true,
              text: "TDS (ppm)",
            },
            beginAtZero: true,
            grid: {
              drawOnChartArea: false,
            },
          },
        },
      },
    });
  }
};