// Water Test Charts using Chart.js
window.renderWaterTestCharts = function (data) {
  // Common Parameters Chart
  const commonCtx = document.getElementById("commonParametersChart");
  if (commonCtx) {
    // Destroy existing chart if it exists
    const existingChart = Chart.getChart(commonCtx);
    if (existingChart) {
      existingChart.destroy();
    }

    new Chart(commonCtx, {
      type: "line",
      data: {
        labels: data.labels,
        datasets: [
          {
            label: "pH",
            data: data.commonParameters.ph,
            borderColor: "#4facfe",
            backgroundColor: "rgba(79, 172, 254, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            yAxisID: "y-ph",
            pointRadius: 4,
            pointHoverRadius: 6,
          },
          {
            label: "Temperature (°F)",
            data: data.commonParameters.temperature,
            borderColor: "#ff6b6b",
            backgroundColor: "rgba(255, 107, 107, 0.1)",
            borderWidth: 2,
            tension: 0.4,
            fill: true,
            yAxisID: "y-temp",
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
            titleFont: {
              size: 14,
            },
            bodyFont: {
              size: 13,
            },
            callbacks: {
              label: function (context) {
                let label = context.dataset.label || "";
                if (label) {
                  label += ": ";
                }
                if (context.parsed.y !== null) {
                  label += context.parsed.y.toFixed(1);
                }
                return label;
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
          "y-ph": {
            type: "linear",
            display: true,
            position: "left",
            title: {
              display: true,
              text: "pH Level",
            },
            min: 6,
            max: 9,
          },
          "y-temp": {
            type: "linear",
            display: true,
            position: "right",
            title: {
              display: true,
              text: "Temperature (°F)",
            },
            min: 70,
            max: 85,
            grid: {
              drawOnChartArea: false,
            },
          },
        },
      },
    });
  }

  // Nitrogen Cycle Chart
  const nitrogenCtx = document.getElementById("nitrogenChart");
  if (nitrogenCtx) {
    const existingChart = Chart.getChart(nitrogenCtx);
    if (existingChart) {
      existingChart.destroy();
    }

    new Chart(nitrogenCtx, {
      type: "line",
      data: {
        labels: data.labels,
        datasets: [
          {
            label: "Ammonia (ppm)",
            data: data.nitrogen.ammonia,
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
            data: data.nitrogen.nitrite,
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
            data: data.nitrogen.nitrate,
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
            titleFont: {
              size: 14,
            },
            bodyFont: {
              size: 13,
            },
            callbacks: {
              label: function (context) {
                let label = context.dataset.label || "";
                if (label) {
                  label += ": ";
                }
                if (context.parsed.y !== null) {
                  label += context.parsed.y.toFixed(2) + " ppm";
                }
                return label;
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

  // Reef Chemistry Chart
  const reefCtx = document.getElementById("reefChemistryChart");
  if (reefCtx) {
    const existingChart = Chart.getChart(reefCtx);
    if (existingChart) {
      existingChart.destroy();
    }

    new Chart(reefCtx, {
      type: "line",
      data: {
        labels: data.labels,
        datasets: [
          {
            label: "Salinity (ppt)",
            data: data.reefChemistry.salinity,
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
            data: data.reefChemistry.alkalinity,
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
            data: data.reefChemistry.calcium,
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
            data: data.reefChemistry.magnesium,
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
            titleFont: {
              size: 14,
            },
            bodyFont: {
              size: 13,
            },
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

  // Hardness Chart
  const hardnessCtx = document.getElementById("hardnessChart");
  if (hardnessCtx) {
    const existingChart = Chart.getChart(hardnessCtx);
    if (existingChart) {
      existingChart.destroy();
    }

    new Chart(hardnessCtx, {
      type: "line",
      data: {
        labels: data.labels,
        datasets: [
          {
            label: "GH (°dH)",
            data: data.hardness.gh,
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
            data: data.hardness.kh,
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
            data: data.hardness.tds,
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
            titleFont: {
              size: 14,
            },
            bodyFont: {
              size: 13,
            },
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