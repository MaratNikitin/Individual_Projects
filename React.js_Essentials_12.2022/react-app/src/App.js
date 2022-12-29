import './App.css';
import { useState, useEffect, useLayoutEffect, useReducer, useRef } from 'react';

// const [firstCity, secondCity, thirdCity] = ["Tokyo", "Tahoe City", "Bend"]

// // custom hook:
// function useInput(initialValue){
//   const [value, setValue] = useState(initialValue);
//   return [
//     {value, onChange: e => setValue(e.target.value)},
//     () => setValue(initialValue)
//   ];
// }

function GitHubUser({name,location,avatar}){
  return (
    <div>
      <h1>{name}</h1>
      <p>{location}</p>
      <img src={avatar} height={200} alt={name}/>
    </div>
  )
}

function App() {

  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    setLoading(true);
    fetch(
      `https://api.github.com/users/maratnikitin`
    )
    .then((response) => response.json())
    .then(setData)
    .then(() => setLoading(false))
    .catch(setError);
  },[]);

  if(loading){
    return <h1>Loading...</h1>
  }

  if(error){
    return <pre>{JSON.stringify(error)}</pre>
  }

  if(!data){
    return null;
  }

  //if(data)
  return (<GitHubUser 
    name={data.name} 
    location={data.location}
    avatar={data.avatar_url} />);
    // return <pre>{JSON.stringify(data, null, 2)}</pre>
  

  // const [title, setTitle] = useState("");
  // const [titleProps, resetTitle] = useInput("");
  // const [colorProps, resetColor] = useInput("#000000");

  // const [checked, setChecked] = useState(false);
  //const [checked, setChecked] = useReducer(checked => !checked, false);

  // const [emotion, setEmotion] = useState("happy");
  // const [secondary, setSecondary] = useState("tired");

  // useEffect(() => {
  //   console.log( `It's ${emotion} right now`);
  // }, [emotion, secondary]);
  
  // useEffect(() => {
  //   console.log(`It's ${secondary} around here`);
  // }, [secondary]);

  // const txtTitle = useRef();
  // const hexColor = useRef();

  // console.log(txtTitle);

  // const submit = e => {
  //   e.preventDefault();
  //   alert(`${titleProps.value}, ${colorProps.value}`);
  //   // const title = txtTitle.current.value;
  //   // const color = hexColor.current.value;
  //   // alert(`${title}, ${color}`);
  //   // txtTitle.current.value = "";
  //   // hexColor.current.value = "";
  //   // setTitle("");
  //   // setColor("#000000");
  //   resetTitle();
  //   resetColor();

  // };

  // return (

  //   <h1> Data </h1>

    // <form onSubmit={submit}>
    //   <input
    //     {...titleProps} 
    //     // ref={txtTitle} 
    //     //value={title}
    //     type="text" 
    //     placeholder='Colour title ...'
    //     //onChange={event => setTitle(event.target.value)} 
    //   />
    //   <input 
    //     {...colorProps}
    //     // ref={hexColor}
    //     //value={color} 
    //     type="color" 
    //     //onChange={event => setColor(event.target.value)} 
    //   />
    //   <button>Add</button>
    // </form>

    // <div className="App">

    //   <input 
    //     type="checkbox" 
    //     value={checked} 
    //     onChange={setChecked}
    //   />
    //   <label> 
    //     {checked ? "Checked" : "Unchecked"} 
    //   </label>

      /* <h1> Hello from {library}! </h1> 
      <h1>Current emotion is {emotion}</h1>
      <button onClick={()=>setEmotion("sad")}>
        Sad
      </button>
      <button onClick={()=>setEmotion("excited")}>
        Excited
      </button>
        <h2>
          Current secondary emotion is {secondary}.
        </h2>
      <button onClick={()=>setSecondary("grateful")}>
        Grateful
      </button> */


    // </div>
  // );
}

export default App;
