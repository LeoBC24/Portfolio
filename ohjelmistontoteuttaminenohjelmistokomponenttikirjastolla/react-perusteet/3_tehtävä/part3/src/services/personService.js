import axios from 'axios';

const baseUrl = 'http://localhost:3001/api/persons'; // Change to your backend URL

// Fetch all persons from the backend
const getAll = () => {
  return axios.get(baseUrl).then((response) => response.data);
};

// Create a new person in the backend
const create = (newPerson) => {
  return axios.post(baseUrl, newPerson).then((response) => response.data);
};

// Update a person's information in the backend
const update = (id, updatedPerson) => {
  return axios.put(`${baseUrl}/${id}`, updatedPerson).then((response) => response.data);
};

// Delete a person from the backend
const remove = (id) => {
  return axios.delete(`${baseUrl}/${id}`).then(() => id);
};

export default { getAll, create, update, remove };
