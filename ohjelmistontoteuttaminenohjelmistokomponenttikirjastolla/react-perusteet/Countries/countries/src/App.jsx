import React, { useState } from 'react';
import axios from 'axios';

const App = () => {
  const [query, setQuery] = useState('');
  const [countries, setCountries] = useState([]);
  const [errorMessage, setErrorMessage] = useState('');

  const handleSearch = async (event) => {
    event.preventDefault();
    if (!query) return;

    try {
      const response = await axios.get(`https://restcountries.com/v3.1/name/${query}`);
      setCountries(response.data);
      setErrorMessage('');
    } catch (error) {
      setCountries([]);
      setErrorMessage('No countries found with that name');
    }
  };

  const renderCountries = () => {
    if (countries.length > 10) {
      return <p>Too many matches, please be more specific.</p>;
    }

    if (countries.length > 1) {
      return (
        <ul>
          {countries.map((country) => (
            <li key={country.cca3}>
              {country.name.common}
            </li>
          ))}
        </ul>
      );
    }

    if (countries.length === 1) {
      const country = countries[0];
      return (
        <div>
          <h1>{country.name.common}</h1>
          <p>Capital: {country.capital ? country.capital[0] : 'N/A'}</p>
          <p>Area: {country.area} km²</p>
          <p>Languages: {Object.values(country.languages || {}).join(', ')}</p>
          <img src={country.flags[0]} alt={`Flag of ${country.name.common}`} width="200" />
        </div>
      );
    }

    return null;
  };

  return (
    <div>
      <h2>Search for countries</h2>
      <form onSubmit={handleSearch}>
        <input 
          type="text" 
          value={query} 
          onChange={(e) => setQuery(e.target.value)} 
          placeholder="Search for a country" 
        />
        <button type="submit">Search</button>
      </form>

      {errorMessage && <p>{errorMessage}</p>}

      {renderCountries()}
    </div>
  );
};

export default App;
