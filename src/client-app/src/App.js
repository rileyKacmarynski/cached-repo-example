import React, { Component } from 'react';
import './App.css';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import TopTracks from './components/top-tracks';
import TrackDetail from './components/track-detail';

class App extends Component {
  render() {
    return (
      <Router>
        <>
          <Route path="/" exact component={TopTracks} />
          <Route path="/tracks/:id" component={TrackDetail} />
        </>
      </Router>
    );
  }
}

export default App;
