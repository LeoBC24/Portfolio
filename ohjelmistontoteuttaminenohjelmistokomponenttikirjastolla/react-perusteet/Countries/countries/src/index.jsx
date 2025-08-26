import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';  // Import the App component
import './index.css';  // Optional: for custom styles

const root = ReactDOM.createRoot(document.getElementById('root'));  // Reference the 'root' div from index.html
root.render(
  <React.StrictMode>
    <App />  {/* Render the App component */}
  </React.StrictMode>
);
