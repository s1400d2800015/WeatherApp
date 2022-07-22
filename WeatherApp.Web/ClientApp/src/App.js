import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { WeatherData } from './components/WeatherData';
import { CityWeather } from './components/CityWeather';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        
            <Route exact path='/' component={WeatherData} />
            <Route path='/city-Weather' component={CityWeather} />
      </Layout>
    );
  }
}
