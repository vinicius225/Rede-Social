import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import router from "./router";
import store from './store/index.js'
import Antd from 'ant-design-vue';

createApp(App).use(router)
.use(store)
.use(Antd)
.mount("#app");
