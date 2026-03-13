import { useEffect, useState } from 'react'

function App() {

  const [data, setData] = useState<any>(null)

  useEffect(() => {
    fetch("/api/health")
      .then(res => res.text())
      .then(data => {
        console.log(data)
        setData(data)
      })
  }, [])

  return (
    <div>
      <h1>Recam Frontend</h1>

      <h2>API Response:</h2>

      <pre>
        {JSON.stringify(data, null, 2)}
      </pre>
    </div>
  )
}

export default App