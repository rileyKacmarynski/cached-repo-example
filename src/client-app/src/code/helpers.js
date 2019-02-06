const baseUrl = 'https://shinookmusicstore.azurewebsites.net/api/';

async function fetchAsync(path) {
  const response = await fetch(baseUrl + path);
  return await response.json();
}

export { fetchAsync };
