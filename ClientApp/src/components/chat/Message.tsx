//this is fully copy and pasted
export const Message = (props) => (
  <div style={{ background: "#eee", borderRadius: "5px", padding: "0 10px" }}>
    <p>
      <strong>{props.user}</strong> says:
    </p>
    <p>{props.message}</p>
  </div>
);
