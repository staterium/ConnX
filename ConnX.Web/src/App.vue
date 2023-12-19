<template>
  <div>
    <input v-model="userInput" placeholder="Enter credit card number">
    <button @click="fetchData">Check Card</button>
    <br/>
    <br/>
    <div v-if="apiResponse">
      <h2>Result:</h2>
      <pre>{{ apiResponse }}</pre>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      userInput: '',
      apiResponse: null,
    };
  },
  methods: {
    fetchData() {
      const apiUrl = `https:/localhost:7244/checkcard/${this.userInput}`; 
      axios.get(apiUrl)
        .then(response => {
          this.apiResponse = response.data;
        })
        .catch(error => {
          console.error('Error fetching data:', error);
          this.apiResponse = 'Error fetching data. Please try again later.';
        });
    },
  },
};
</script>
