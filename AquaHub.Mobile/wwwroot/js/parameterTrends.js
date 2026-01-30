// Parameter Trends Charts using Chart.js
window.renderParameterTrendChart = function (canvasId, data) {
  const ctx = document.getElementById(canvasId);
  if (!ctx) return;

  // Destroy existing chart if it exists
  const existingChart = Chart.getChart(ctx);
  if (existingChart) {
    existingChart.destroy();
  }

  const datasets = [
    {
      label: data.parameterName,
      data: data.values,
      borderColor: "#667eea",
      backgroundColor: "rgba(102, 126, 234, 0.1)",
      borderWidth: 3,
      tension: 0.4,
      fill: true,
      pointRadius: 5,
      pointHoverRadius: 7,
      pointBackgroundColor: "#667eea",
      pointBorderColor: "#fff",
      pointBorderWidth: 2,
      pointHoverBackgroundColor: "#fff",
      pointHoverBorderColor: "#667eea",
    },
  ];

  // Add ideal range lines if they exist
  if (data.idealMin !== null && data.idealMax !== null) {
    datasets.push({
      label: "Ideal Max",
      data: new Array(data.labels.length).fill(data.idealMax),
      borderColor: "#66bb6a",
      backgroundColor: "transparent",
      borderWidth: 2,
      borderDash: [5, 5],
      pointRadius: 0,
      fill: false,
    });

    datasets.push({
      label: "Ideal Min",
      data: new Array(data.labels.length).fill(data.idealMin),
      borderColor: "#66bb6a",
      backgroundColor: "rgba(102, 187, 106, 0.1)",
      borderWidth: 2,
      borderDash: [5, 5],
      pointRadius: 0,
      fill: "-1",
    });
  } else if (data.idealMax !== null) {
    datasets.push({
      label: "Safe Maximum",
      data: new Array(data.labels.length).fill(data.idealMax),
      borderColor: "#ff6b6b",
      backgroundColor: "transparent",
      borderWidth: 2,
      borderDash: [5, 5],
      pointRadius: 0,
      fill: false,
    });
  }

  new Chart(ctx, {
    type: "line",
    data: {
      labels: data.labels,
      datasets: datasets,
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
          labels: {
            usePointStyle: true,
            padding: 15,
            font: {
              size: 12,
            },
          },
        },
        tooltip: {
          backgroundColor: "rgba(0, 0, 0, 0.8)",
          padding: 12,
          titleFont: {
            size: 14,
            weight: "bold",
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
                label += context.parsed.y.toFixed(2) + (data.unit || "");
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
          ticks: {
            maxRotation: 45,
            minRotation: 45,
          },
        },
        y: {
          beginAtZero: false,
          title: {
            display: true,
            text:
              data.parameterName + (data.unit ? " (" + data.unit + ")" : ""),
          },
          grid: {
            color: "rgba(0, 0, 0, 0.05)",
          },
        },
      },
    },
  });
};
