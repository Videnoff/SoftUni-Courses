import logo from './logo.svg';
import './App.css';
import LearnReact from "./LearnReact";
import Code from "./Code";

function App() {
  const renderResult = (a, b) => {
    return a + b;
  }

  fetch('google.com').then(() => {
    // logic
  })
  return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo"/>
          <p>
            Edit
            <Code>
              <p>
              src/App.js
              </p>
            </Code> and save to reload.
          </p>
          <p>
            Result: {renderResult(1, 2)}
          </p>
          <LearnReact />
          <a
              className="App-link"
              href="https://reactjs.org"
              target="_blank"
              rel="noopener noreferrer"
          >
            Learn React
          </a>
          <Code>
            test
          </Code>
        </header>
      </div>
  );
}

export default App;
