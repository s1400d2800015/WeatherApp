import react, { Component } from 'react';

export class CityWeather extends Component {


    static displayName = CityWeather.name;

    render()
    {
        function onSubmit() {
            e.preventDefault()

            alert('button clicked')
            return
        }

        return (
         <div>
                <div className="card"><div className="card-body">
                    <h4 className="card-title">Fetch Weather Data by City Name</h4>
                  <hr></hr>
                    <form className='add-form' onSubmit={onSubmit}>
                        City :
                        <input
                            type='text'
                            placeholder='City Name'
                        />
                        <input type='submit' value='Submit' className='btn btn-block' />
                    </form>

                  
              </div>
              </div>
          </div>
            )
    }
}