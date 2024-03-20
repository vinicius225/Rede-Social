import { configureStore } from "@reduxjs/toolkit";

import React from "react";
import authReducer from "./slices/authSlice";

export default function store() {
  reducer = {
    auth: authReducer,
  };
}
