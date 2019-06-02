// file-upload.js

import axios from 'axios';
import { Configuration } from '../Configuration'

const BASE_URL = Configuration.ServerPath;

function upload(formData) {
  const url = `${BASE_URL}`;
  return axios.post('file/Post', formData, { headers: { 'Content-Type': 'multipart/form-data' } })
    // get data
    .then(x => {
      let data = x.data;
      var mapped = data.map(img => { return Object.assign({}, img, { url: `${BASE_URL}/img/${img.uploadedFileName}` }); })
      return mapped;
    })
};

export { upload }
