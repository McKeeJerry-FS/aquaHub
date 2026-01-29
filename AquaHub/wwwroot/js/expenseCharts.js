// Expense Charts using Chart.js

window.expenseCharts = {
  categoryChart: null,
  monthlyChart: null,
  trendChart: null,

  createCategoryPieChart: function (canvasId, data) {
    const ctx = document.getElementById(canvasId);
    if (!ctx) return;

    if (this.categoryChart) {
      this.categoryChart.destroy();
    }

    const labels = data.map((d) => d.category);
    const amounts = data.map((d) => d.amount);
    const colors = [
      "rgb(54, 162, 235)", // Equipment - blue
      "rgb(75, 192, 192)", // Livestock - teal
      "rgb(76, 175, 80)", // Plants - green
      "rgb(255, 206, 86)", // Food - yellow
      "rgb(255, 99, 132)", // Medications - red
      "rgb(153, 102, 255)", // Water Treatment - purple
      "rgb(139, 69, 19)", // Substrate - brown
      "rgb(255, 159, 64)", // Decorations - orange
      "rgb(201, 203, 207)", // Maintenance - gray
      "rgb(100, 100, 100)", // Electricity - dark gray
      "rgb(0, 191, 255)", // Water - light blue
      "rgb(255, 0, 255)", // Testing - magenta
      "rgb(128, 128, 128)", // Other - gray
    ];

    this.categoryChart = new Chart(ctx, {
      type: "doughnut",
      data: {
        labels: labels,
        datasets: [
          {
            data: amounts,
            backgroundColor: colors.slice(0, labels.length),
            borderWidth: 2,
            borderColor: "#fff",
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            position: "right",
          },
          title: {
            display: true,
            text: "Spending by Category",
          },
          tooltip: {
            callbacks: {
              label: function (context) {
                const label = context.label || "";
                const value = context.parsed || 0;
                const total = context.dataset.data.reduce((a, b) => a + b, 0);
                const percentage = ((value / total) * 100).toFixed(1);
                return (
                  label + ": $" + value.toFixed(2) + " (" + percentage + "%)"
                );
              },
            },
          },
        },
      },
    });
  },

  createMonthlyBarChart: function (canvasId, data) {
    const ctx = document.getElementById(canvasId);
    if (!ctx) return;

    if (this.monthlyChart) {
      this.monthlyChart.destroy();
    }

    const labels = data.map((d) => d.month);
    const amounts = data.map((d) => d.amount);

    this.monthlyChart = new Chart(ctx, {
      type: "bar",
      data: {
        labels: labels,
        datasets: [
          {
            label: "Monthly Spending",
            data: amounts,
            backgroundColor: "rgba(54, 162, 235, 0.6)",
            borderColor: "rgb(54, 162, 235)",
            borderWidth: 2,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: false,
          },
          title: {
            display: true,
            text: "Monthly Spending Trend",
          },
          tooltip: {
            callbacks: {
              label: function (context) {
                return "$" + context.parsed.y.toFixed(2);
              },
            },
          },
        },
        scales: {
          y: {
            beginAtZero: true,
            title: {
              display: true,
              text: "Amount ($)",
            },
            ticks: {
              callback: function (value) {
                return "$" + value.toFixed(0);
              },
            },
          },
          x: {
            title: {
              display: true,
              text: "Month",
            },
          },
        },
      },
    });
  },

  createTrendLineChart: function (canvasId, data) {
    const ctx = document.getElementById(canvasId);
    if (!ctx) return;

    if (this.trendChart) {
      this.trendChart.destroy();
    }

    const labels = data.map((d) => d.month);
    const amounts = data.map((d) => d.amount);

    // Calculate moving average
    const movingAvg = [];
    const period = 3;
    for (let i = 0; i < amounts.length; i++) {
      if (i < period - 1) {
        movingAvg.push(null);
      } else {
        const sum = amounts
          .slice(i - period + 1, i + 1)
          .reduce((a, b) => a + b, 0);
        movingAvg.push(sum / period);
      }
    }

    this.trendChart = new Chart(ctx, {
      type: "line",
      data: {
        labels: labels,
        datasets: [
          {
            label: "Monthly Spending",
            data: amounts,
            borderColor: "rgb(54, 162, 235)",
            backgroundColor: "rgba(54, 162, 235, 0.1)",
            tension: 0.4,
            fill: true,
          },
          {
            label: "3-Month Average",
            data: movingAvg,
            borderColor: "rgb(255, 99, 132)",
            backgroundColor: "transparent",
            borderDash: [5, 5],
            tension: 0.4,
            pointRadius: 0,
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
            text: "Spending Trend Over Time",
          },
          tooltip: {
            callbacks: {
              label: function (context) {
                return (
                  context.dataset.label + ": $" + context.parsed.y.toFixed(2)
                );
              },
            },
          },
        },
        scales: {
          y: {
            beginAtZero: true,
            title: {
              display: true,
              text: "Amount ($)",
            },
            ticks: {
              callback: function (value) {
                return "$" + value.toFixed(0);
              },
            },
          },
          x: {
            title: {
              display: true,
              text: "Month",
            },
          },
        },
      },
    });
  },

  destroyCharts: function () {
    if (this.categoryChart) {
      this.categoryChart.destroy();
      this.categoryChart = null;
    }
    if (this.monthlyChart) {
      this.monthlyChart.destroy();
      this.monthlyChart = null;
    }
    if (this.trendChart) {
      this.trendChart.destroy();
      this.trendChart = null;
    }
  },
};
