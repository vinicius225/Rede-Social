import axios from "axios";
import store from '@/store'; 
import user from './user.js';
debugger
const instance = axios.create({
    baseUrl : process.env.VUE_APP_API_BACKEND
});

instance.defaults.timeout = 1200000

instance.defaults.headers.post["Content-Type"] = "json";
instance.defaults.headers.put["Content-Type"] = "json";
instance.defaults.responseType = "json";
instance.interceptors.request.use((config) => {
	debugger
	if (store.state.user.token)
		config.headers[
			"Authorization"
		] = `Bearer ${store.state.autenticacao.token}`;

	return config;
});

export default {
    ...user({instance})
}


