import React, { Component } from 'react';

export class WeatherData extends Component {
    static displayName = WeatherData.name;

  constructor(props) {
    super(props);
    this.state = { weatherData: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

    static renderweatherDataTable(weatherData) {
       
        return (
          
            <div>
                <div className="card"><div className="card-body">
                    <h5 className="card-title">{weatherData.name}</h5>
                    <h4 className="card-title">Weather: {weatherData.weather[0].main }</h4>

                    <h6 className="card-subtitle mb-2">Current temperature: <i>{weatherData.main.celsius_temp}</i> &#8451;</h6>
                    <p className="card-text">Feels Like: {weatherData.main.celsius_feels_like} &#8451;</p>
                    <p className="card-text">Max:  {weatherData.main.celsius_temp_max} &#8451;, Min: {weatherData.main.celsius_temp_min} &#8451;</p>
                    <div id="img-container">{weatherData.weather.description} <img src={"https://openweathermap.org/img/wn/" +  weatherData.weather[0].icon  + "@2x.png" }></img>
                  </div>
              </div>
              </div>
          </div>
        );

       
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : WeatherData.renderweatherDataTable(this.state.weatherData);

    return (
      <div>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
      const response = await fetch('weather/get');
    const data = await response.json();
      this.setState({ weatherData: data.result, loading: false });
      
    }

}
