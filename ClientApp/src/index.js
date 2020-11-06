import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import reportWebVitals from './reportWebVitals';
import Entry from "./components/Entry/Entry"
import {createStore} from 'redux'
import {Provider} from 'react-redux'
import HandlerDoc from './store/handlers/handler.doc'
import { devToolsEnhancer } from 'redux-devtools-extension';

const store = createStore(HandlerDoc, devToolsEnhancer());

ReactDOM.render(
  <React.StrictMode>
    <Provider store = {store}>
      <Entry />
    </Provider>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
