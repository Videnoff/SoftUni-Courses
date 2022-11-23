import logo from './logo.svg';
import './App.css';
import Code from "./Code";

const App = (props) => {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
          <p>
              Functional Components
          </p>
          <p>
              {props.name}
          </p>
        <p>
          Edit
            <Code number={props.number}>
                <p>
                    src/App.js
                </p>
            </Code> and save to reload.
        </p>
          Learn React
      </header>
    </div>
  );
}

export default App;
