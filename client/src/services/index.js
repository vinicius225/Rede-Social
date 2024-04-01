import { Axios } from "axios";
import user from './user.js'
const instance = Axios.create({
    baseUrl : process.env.API_BACKEND
});

instance.defaults.timeout = 1200000

instance.defaults.headers.post["Content-Type"] = "json";
instance.defaults.headers.put["Content-Type"] = "json";
instance.defaults.responseType = "json";
instance.interceptors.request.use((config) => {
	if (store.state.user.token)
		config.headers[
			"Authorization"
		] = `Bearer ${store.state.autenticacao.token}`;

	return config;
});

export default {
    ...user({instance})
}


