// Growth Tracker Charts using Chart.js

window.growthCharts = {
  lengthChart: null,
  weightChart: null,

  createLengthChart: function (canvasId, data) {
    const ctx = document.getElementById(canvasId);
    if (!ctx) return;

    // Destroy existing chart if it exists
    if (this.lengthChart) {
      this.lengthChart.destroy();
    }

    // Prepare data
    const labels = data.map((d) => new Date(d.date).toLocaleDateString());
    const lengths = data.map((d) => d.length);

    this.lengthChart = new Chart(ctx, {
      type: "line",
      data: {
        labels: labels,
        datasets: [
          {
            label: "Length (inches)",
            data: lengths,
            borderColor: "rgb(75, 192, 192)",
            backgroundColor: "rgba(75, 192, 192, 0.2)",
            tension: 0.4,
            fill: true,
            pointRadius: 5,
            pointHoverRadius: 7,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: true,
            position: "top",
          },
          title: {
            display: true,
            text: "Length Growth Over Time",
          },
          tooltip: {
            callbacks: {
              label: function (context) {
                return (
                  context.dataset.label +
                  ": " +
                  context.parsed.y.toFixed(2) +
                  '"'
                );
              },
            },
          },
        },
        scales: {
          y: {
            beginAtZero: false,
            title: {
              display: true,
              text: "Length (inches)",
            },
            ticks: {
              callback: function (value) {
                return value.toFixed(2) + '"';
              },
            },
          },
          x: {
            title: {
              display: true,
              text: "Date",
            },
          },
        },
      },
    });
  },

  createWeightChart: function (canvasId, data) {
    const ctx = document.getElementById(canvasId);
    if (!ctx) return;

    // Destroy existing chart if it exists
    if (this.weightChart) {
      this.weightChart.destroy();
    }

    // Prepare data
    const labels = data.map((d) => new Date(d.date).toLocaleDateString());
    const weights = data.map((d) => d.weight);

    this.weightChart = new Chart(ctx, {
      type: "line",
      data: {
        labels: labels,
        datasets: [
          {
            label: "Weight (grams)",
            data: weights,
            borderColor: "rgb(255, 159, 64)",
            backgroundColor: "rgba(255, 159, 64, 0.2)",
            tension: 0.4,
            fill: true,
            pointRadius: 5,
            pointHoverRadius: 7,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: true,
            position: "top",
          },
          title: {
            display: true,
            text: "Weight Growth Over Time",
          },
          tooltip: {
            callbacks: {
              label: function (context) {
                return (
                  context.dataset.label +
                  ": " +
                  context.parsed.y.toFixed(1) +
                  "g"
                );
              },
            },
          },
        },
        scales: {
          y: {
            beginAtZero: false,
            title: {
              display: true,
              text: "Weight (grams)",
            },
            ticks: {
              callback: function (value) {
                return value.toFixed(1) + "g";
              },
            },
          },
          x: {
            title: {
              display: true,
              text: "Date",
            },
          },
        },
      },
    });
  },

  createCombinedChart: function (canvasId, lengthData, weightData) {
    const ctx = document.getElementById(canvasId);
    if (!ctx) return;

    // Prepare data
    const labels = lengthData.map((d) => new Date(d.date).toLocaleDateString());

    const datasets = [];

    if (lengthData.some((d) => d.length !== null)) {
      datasets.push({
        label: "Length (inches)",
        data: lengthData.map((d) => d.length),
        borderColor: "rgb(75, 192, 192)",
        backgroundColor: "rgba(75, 192, 192, 0.2)",
        yAxisID: "y-length",
        tension: 0.4,
        pointRadius: 5,
      });
    }

    if (weightData && weightData.some((d) => d.weight !== null)) {
      datasets.push({
        label: "Weight (grams)",
        data: weightData.map((d) => d.weight),
        borderColor: "rgb(255, 159, 64)",
        backgroundColor: "rgba(255, 159, 64, 0.2)",
        yAxisID: "y-weight",
        tension: 0.4,
        pointRadius: 5,
      });
    }

    new Chart(ctx, {
      type: "line",
      data: {
        labels: labels,
        datasets: datasets,
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        interaction: {
          mode: "index",
          intersect: false,
        },
        plugins: {
          legend: {
            display: true,
            position: "top",
          },
          title: {
            display: true,
            text: "Growth Measurements Over Time",
          },
        },
        scales: {
          "y-length": {
            type: "linear",
            display: datasets.some((d) => d.yAxisID === "y-length"),
            position: "left",
            title: {
              display: true,
              text: "Length (inches)",
            },
            ticks: {
              callback: function (value) {
                return value.toFixed(2) + '"';
              },
            },
          },
          "y-weight": {
            type: "linear",
            display: datasets.some((d) => d.yAxisID === "y-weight"),
            position: "right",
            title: {
              display: true,
              text: "Weight (grams)",
            },
            ticks: {
              callback: function (value) {
                return value.toFixed(1) + "g";
              },
            },
            grid: {
              drawOnChartArea: false,
            },
          },
          x: {
            title: {
              display: true,
              text: "Date",
            },
          },
        },
      },
    });
  },

  createCoralGrowthChart: function (canvasId, data) {
    const ctx = document.getElementById(canvasId);
    if (!ctx) return;

    const labels = data.map((d) => new Date(d.date).toLocaleDateString());
    const datasets = [];

    if (data.some((d) => d.diameter !== null)) {
      datasets.push({
        label: "Diameter (inches)",
        data: data.map((d) => d.diameter),
        borderColor: "rgb(153, 102, 255)",
        backgroundColor: "rgba(153, 102, 255, 0.2)",
        tension: 0.4,
        pointRadius: 5,
      });
    }

    if (data.some((d) => d.height !== null)) {
      datasets.push({
        label: "Height (inches)",
        data: data.map((d) => d.height),
        borderColor: "rgb(255, 99, 132)",
        backgroundColor: "rgba(255, 99, 132, 0.2)",
        tension: 0.4,
        pointRadius: 5,
      });
    }

    new Chart(ctx, {
      type: "line",
      data: {
        labels: labels,
        datasets: datasets,
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: true,
            position: "top",
          },
          title: {
            display: true,
            text: "Coral/Plant Growth Over Time",
          },
        },
        scales: {
          y: {
            beginAtZero: false,
            title: {
              display: true,
              text: "Size (inches)",
            },
            ticks: {
              callback: function (value) {
                return value.toFixed(2) + '"';
              },
            },
          },
          x: {
            title: {
              display: true,
              text: "Date",
            },
          },
        },
      },
    });
  },

  destroyCharts: function () {
    if (this.lengthChart) {
      this.lengthChart.destroy();
      this.lengthChart = null;
    }
    if (this.weightChart) {
      this.weightChart.destroy();
      this.weightChart = null;
    }
  },
};
