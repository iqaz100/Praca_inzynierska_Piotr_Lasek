import React from 'react';
import ReactDOM from 'react-dom';
import { createStore } from 'redux';
import { Provider } from 'react-redux';

import App from './App';
import UnloggedUser from './UnloggedUser'
import './index.css';

//ReactDOM.render(<App />, document.getElementById('root'));

const reducer = (state, action) => {
    switch (action.type) {
      case 'LOGIN':
        return { ...state, logged: false };
      case 'LOGOUT':
        return { ...state, logged: true };
      default:
        return state;
      }
  };

  const store = createStore(reducer, { logged: false });
  
  if(localStorage.getItem('user')) {
    store.dispatch({ type: 'LOGIN' });
  } else {
    store.dispatch({ type: 'LOGOUT' });
  }
  

if(localStorage.getItem('user')) {
    ReactDOM.render(
      <Provider store={store}>
        <App />
      </Provider> 
      , document.getElementById('root')
    );
  } else {
    ReactDOM.render(
      <Provider store={store}>
          <UnloggedUser/>
      </Provider> 
      , document.getElementById('root')
    );
  }